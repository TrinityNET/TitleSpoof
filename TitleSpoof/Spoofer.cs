using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitleSpoof
{
    class Spoofer
    {
        public static void Populate(DataGridView Grid)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Grid.Rows.Add(process.ProcessName, process.MainWindowTitle, process.MainWindowHandle);
                }
            }
            Thread.Sleep(500);
        }
    }

    public class WindowSpoofer
    {
        [DllImport("User32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string lParam);

        public void Set(string processName, string titleText, int index)
        {
            Process p = Process.GetProcessesByName(processName)[index];
            if (p != null)
            {
                IntPtr hWnd = p.MainWindowHandle;
                SetWindowText(hWnd, titleText);
            }
            else
            {
                throw new Exception($"{processName} is not running/ is null(or)empty!");
            }
        }
    }
}
