using System;
using System.Threading;
using System.Windows.Forms;
using MediaPlayer.Forms;
using MediaPlayer.Presenters;

namespace MediaPlayer;

internal static class Program 
{
    [STAThread]
    private static void Main(string[] args)
    {
        using var mutex = new Mutex(true, "MediaPlayer", out var oneOnly);
        
        if (oneOnly)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args.Length == 0 ? null : args, new AudioPresenter()));
            mutex.ReleaseMutex();
        }
        else if (args.Length != 0)
        {
        }
    }
}