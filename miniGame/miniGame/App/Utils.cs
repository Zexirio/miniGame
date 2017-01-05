using System;
using System.Windows.Forms;

namespace miniGame {
    static class Utils {
        /**Act like multithreading*/
        public static bool ControlInvokeRequired(Control c, Action a) {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;
            return true;
        }
    }
}
