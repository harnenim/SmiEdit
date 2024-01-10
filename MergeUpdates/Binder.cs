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

        public void Focus(string target)
        {
            _.FocusWindow(target);
        }

        public void InitAfterLoad() { }

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

        public void DropFileToArea(int dropArea)
        {
            _.DropFileToArea(dropArea);
        }
        public void Save(string dir, string name, string text)
        {
            _.Save(dir, name, text);
        }
    }
}
