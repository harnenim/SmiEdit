using CefSharp.Structs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.IO;
using System.Reflection;

namespace Jamaker
{
    class BaseBinder
    {
        private readonly MainForm _;

        public BaseBinder(MainForm webForm)
        {
            _ = webForm;
        }

        public void Focus(string target)
        {
            _.FocusWindow(target);
        }

        public void InitAfterLoad(string title)
        {
            _.InitAfterLoad(title);
        }

        public void ShowDragging()
        {
            _.ShowDragging();
        }
        public void HideDragging()
        {
            _.HideDragging();
        }

        public void Alert(string target, string msg) { _.Alert(target, msg); }
        public void Confirm(string target, string msg) { _.Confirm(target, msg); }
    }

    class Binder : BaseBinder
    {
        private readonly MainForm _;

        public Binder(MainForm mainForm) : base(mainForm)
        {
            _ = mainForm;
        }

        public void ExitAfterSaveSetting(string setting)
        {
            _.ExitAfterSaveSetting(setting);
        }
        public void OpenFileDialog(int type, bool withSaveSkf)
        {
            _.OpenFileDialog(type, withSaveSkf);
        }
        public void DropOriginFile(bool withSaveSkf)
        {
            _.DropOriginFile(withSaveSkf);
        }
        public void DropTargetFile(bool withSaveSkf)
        {
            _.DropTargetFile(withSaveSkf);
        }
        public void SelectAudio(int index)
        {
            _.SelectAudio(index);
        }
        public void CalcShift(string ranges, string shifts)
        {
            _.CalcShift(ranges, shifts);
        }
        public void Save(string result, string operation)
        {
            _.Save(result, operation);
        }
        /*
        public void Exit()
        {
            _.Exit();
        }
        */
    }
}
