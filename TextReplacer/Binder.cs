using System.Collections.Generic;

namespace Jamaker
{
    class Binder
    {
        private readonly MainForm _;

        public Binder(MainForm mainForm)
        {
            _ = mainForm;
        }

        public void MoveWindow(string target, int x, int y, int width, int height, bool resizable)
        {
            _.MoveWindow(target, x, y, width, height, resizable);
        }
        public void Focus(string target)
        {
            _.FocusWindow(target);
        }

        public void InitAfterLoad()
        {
            _.Init();
        }

        public void Submit(string[] files, string[] froms, string[] tos)
        {
            _.Submit(files, froms, tos);
        }

        public void ImportSetting()
        {
            _.ImportSetting();
        }

        public void ExportSetting(string setting)
        {
            _.ExportSetting(setting);
        }

        public void Compare(string file, string[] froms, string[] tos)
        {
            _.Compare(file, froms, tos);
        }

        public void ExitAfterSaveSetting(string setting)
        {
            _.ExitAfterSaveSetting(setting);
        }

        public void ShowDragging()
        {
            _.ShowDragging();
        }
        public void HideDragging()
        {
            _.HideDragging();
        }

        public void AddFiles()
        {
            _.AddFiles();
        }
        public void LoadSetting()
        {
            _.LoadSetting();
        }
        
        #region 팝업 통신
        public void Alert  (string target, string msg) { _.Alert  (target, msg); }
        public void Confirm(string target, string msg) { _.Confirm(target, msg); }
        #endregion
    }
}
