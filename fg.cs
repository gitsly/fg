using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
//using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace fg
{
    class Program
    {
        private static string usage = "fg [processName]";

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        static void SetAsForeGroundWindow(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);
            // Activate the first application we find with this name
            if (p.Count() > 0)
                SetForegroundWindow(p[0].MainWindowHandle);
        }

        static void Main(string[] args)
        {

            if (args.Count() < 1)
            {
                Console.WriteLine(usage);
                return;
            }

            SetAsForeGroundWindow(args[0]);
        }
    }
}
