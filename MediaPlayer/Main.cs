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
        using var mutex = new Mutex(true, "MediaPlayer_hash", out var onlyOne);

        if (!onlyOne)
        {
            return;
        }
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(args, new MainFormPresenter()));
        mutex.ReleaseMutex();
    }
}