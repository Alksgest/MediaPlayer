using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    static class Program 
    {
        private static List<string> list = new List<string>();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(true, "MediaPlayer", out bool oneOnly))
            {
                if (oneOnly)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm(args.Length == 0 ? null : args));
                    mutex.ReleaseMutex();
                }
                else if (args.Length != 0)
                {
                }
            }
        }
    }
}
