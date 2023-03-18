using System;
using System.Collections.Generic;
using Subtitle;

namespace SmiManager
{
    static class Shaker
    {
        private static float FRAME_LENGTH = 1001 / 24.0f; // 24fps

        private class ShakeSmiLines
        {
            static int SIZE = 1;
            private string[] lines;
            public ShakeSmiLines(string smi)
            {
                //lines = Combiner.Combined.ToLines(smi);
            }
            public string ToSmi(int phase)
            {
                phase = phase % 8;
                // 0: 0 1 1 2
                // 1: 2 0 2 0
                // 2: 1 2 0 1
                // 3: 0 0 2 2
                // 4: 2 1 1 0
                // 5: 0 2 0 2
                // 6: 1 0 2 1
                // 7: 2 2 0 0

                int top = SIZE;
                if (phase % 4 == 2) top = SIZE * 2; // 2, 6
                if (phase % 3 == 1) top = SIZE * 3; // 1, 4, 7
                int bottom = SIZE * 4 - top;

                int left = 2;
                int tPhase = (phase + 5) % 8;
                if (tPhase % 3 == 0) left = 0;
                if (tPhase % 4 == 1) left = 1;
                int right = 2 - left;

                string sLeft = "", sRight = "";
                for (int i = 0; i < left; i++) sLeft += " ";
                for (int i = 0; i < right; i++) sRight += " ";

                string result = string.Format("<font size=\"{0}\">　</font><br>", top);
                foreach (string line in lines)
                    result += "​" + sLeft + line + sRight + "​" + "<br>";
                return result + string.Format("<font size=\"{0}\">　</font>", bottom);
            }
        }
        public static List<Smi> Shake(List<Smi> input)
        {
            List<Smi> output = new List<Smi>();

            int phase = 0;
            for (int i = 0; i < input.Count - 1; i++)
            {
                Smi smi = input[i];
                if (smi.text.Replace("&nbsp;", "").Trim().Length == 0)
                {
                    output.Add(smi);
                }
                else
                {
                    int start = smi.start, end = input[i + 1].start;
                    int time = end - start;
                    ShakeSmiLines lines = new ShakeSmiLines(smi.text);

                    int frames = (int)Math.Round(time / FRAME_LENGTH);
                    if (frames < 1) frames = 1;
                    for (int frame = 0; frame < frames; frame++)
                    {
                        output.Add(new Smi()
                        {
                            start = (start * (frames - frame) + end * frame) / frames,
                            syncType = (frame == 0 ? smi.syncType : SyncType.inner),
                            text = lines.ToSmi(phase++)
                        });
                    }
                }
            }
            if (input.Count > 0)
            {   // 마지막 싱크는 흔들기 처리 없이 루프 밖에 위치
                output.Add(input[input.Count - 1]);
            }
            return output;
        }
    }
}
