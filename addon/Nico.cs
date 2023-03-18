using System;
using System.Collections.Generic;
using Subtitle;

namespace SmiManager
{   // TODO: 옛날에 C#으로 짜둔 건데 재활용할 수 있나...
    static class NicoNico
    {
        private static float FRAME_LENGTH = 1001 / 24.0f; // 24fps

        public class NicoLine
        {
            public static float lineWidth = 100;
            public int line;
            public int start;
            public int end;
            public float width;
            public string text;
            public float CalcLeft(int frame)
            {
                float time = frame * FRAME_LENGTH;
                return lineWidth - ((lineWidth + width) * (time - start) / (end - start));
            }

        }

        // Cut 함수는 SubtitleObject.dll로 빼는 게 나을 듯?
        private static string CutLineRightToWidth(string line, double width)
        {
            string last3 = line;
            float t = 0;
            while ((t = Smi.GetLineWidth(line)) > width)
            {
                last3 = line;
                line = line.Substring(0, line.Length - 1);
            }
            string last1 = line;
            while (Smi.GetLineWidth(line) < width)
            {
                last1 = line;
                line += " ";
            }
            if (width - Smi.GetLineWidth(last1) < Smi.GetLineWidth(line) - width)
            {
                line = last1;
                if (Smi.GetLineWidth(last3) - width < width - Smi.GetLineWidth(line))
                    line = last3;
            }
            return line;
        }
        private static string CutLineLeftToWidth(string line, double width)
        {
            string last3 = line;
            while (Smi.GetLineWidth(line) > width)
            {
                last3 = line;
                line = line.Substring(1);
            }
            string last1 = line;
            while (Smi.GetLineWidth(line) < width)
            {
                last1 = line;
                line = " " + line;
            }
            if (width - Smi.GetLineWidth(last1) < Smi.GetLineWidth(line) - width)
            {
                line = last1;
                if (Smi.GetLineWidth(last3) - width < width - Smi.GetLineWidth(line))
                    line = last3;
            }
            return line;
        }

        public static List<Smi> Nico(List<NicoLine> nicoLines, int width)
        {
            int lineCount = 0;
            int startOfAll = int.MaxValue;
            int endOfAll = 0;

            foreach (NicoLine line in nicoLines)
            {
                if (line.line > lineCount) lineCount = line.line;
                if (line.start < startOfAll) startOfAll = line.start;
                if (line.end > endOfAll) endOfAll = line.end;
            }

            int startFrame = (int)Math.Round(startOfAll / FRAME_LENGTH);
            int endFrame = (int)Math.Round(endOfAll / FRAME_LENGTH);

            List<List<NicoLine>> lines = new List<List<NicoLine>>();
            for (int i = 0; i < lineCount; i++)
                lines.Add(new List<NicoLine>());

            foreach (NicoLine line in nicoLines)
                lines[line.line - 1].Add(line);

            string defaultValue = "";
            for (int i = 0; i < width; i++)
                defaultValue += "　";
            NicoLine.lineWidth = Smi.GetLineWidth(defaultValue);
            
            List<Smi> output = new List<Smi>();
            for (int frame = startFrame; frame < endFrame; frame++)
            {
                Smi smi = new Smi()
                {
                    start = (int)(frame * FRAME_LENGTH),
                    syncType = (frame == startFrame ? SyncType.frame : SyncType.inner),
                    text = "​"
                };
                for (int i = 0; i < lineCount; i++)
                {
                    string result = defaultValue;
                    foreach (NicoLine line in lines[i])
                    {
                        float pos = line.CalcLeft(frame);
                        if (pos < 0)
                        {   // 왼쪽이 잘리기 시작
                            float leftWidth = pos + line.width;
                            if (leftWidth > 0)
                            {   // 화면에 남는 부분이 있음
                                if (leftWidth >= NicoLine.lineWidth)
                                {   // 남는 부분이 화면보다 큼
                                    result = CutLineLeftToWidth(line.text, leftWidth);
                                    result = CutLineRightToWidth(line.text, NicoLine.lineWidth);
                                }
                                else
                                {   // 남는 부분이 화면보다 작음
                                    string text = CutLineLeftToWidth(line.text, leftWidth);
                                    result = text + CutLineLeftToWidth(result, NicoLine.lineWidth - leftWidth);
                                }
                            }
                        }
                        else if (pos < NicoLine.lineWidth)
                        {   // 화면 안에서 시작
                            string lastResult = result;
                            result = CutLineRightToWidth(result, pos) + line.text;
                            float thisWidth = Smi.GetLineWidth(result);
                            if (thisWidth > NicoLine.lineWidth)
                                result = CutLineRightToWidth(result, NicoLine.lineWidth);
                            else
                                result += CutLineLeftToWidth(lastResult, NicoLine.lineWidth - thisWidth);
                        }
                    }
                    smi.text += (i == 0 ? "" : "<br>") + result;
                }
                smi.text += "​";
                output.Add(smi);
            }
            output.Add(new Smi()
            {
                start = (int)(endFrame * FRAME_LENGTH),
                syncType = SyncType.frame,
                text = "&nbsp;"
            });

            return output;
        }
    }
}
