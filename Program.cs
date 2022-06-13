using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitAMoment
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var args = System.Environment.GetCommandLineArgs();
            if (args.Length < 2)
            {
                System.Environment.Exit(1);
                return;
            }
            if ( args.Length >= 2 && args[1] != "/C")
            {

                var myAssembly = System.Reflection.Assembly.GetEntryAssembly();
                string myExePath = myAssembly.Location;

                var processInfo = new System.Diagnostics.ProcessStartInfo();
                processInfo.UseShellExecute = true;
                processInfo.Arguments = "/C \"" + args[1] + "\"";
                processInfo.FileName = myExePath;

                System.Diagnostics.Process.Start(processInfo);
                System.Environment.Exit(0);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1( System.IO.Path.GetFileNameWithoutExtension(args[2])));
        }
    }
}
