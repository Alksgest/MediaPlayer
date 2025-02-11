using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MediaPlayer.Helpers;

public class KeyboardListener : IDisposable
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    
    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private readonly IntPtr _hookId;

    public KeyboardListener()
    {
        LowLevelKeyboardProc proc = HookCallback;
        _hookId = SetHook(proc);
    }
    
    // Constants for the hook and key messages
    private const int WhKeyboardLl = 13;
    private const int WmKeydown = 0x0100;
    // private const int WmKeyup = 0x0101;
    
    public event Action<Keys> OnKeyDown;
    
    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using var curProcess = Process.GetCurrentProcess();
        using var curModule = curProcess.MainModule;
        
        return SetWindowsHookEx(WhKeyboardLl, proc, GetModuleHandle(curModule?.ModuleName), 0);
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode < 0)
        {
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
        
        switch (wParam)
        {
            case WmKeydown:
            {
                var vkCode = Marshal.ReadInt32(lParam);
                var key = (Keys)vkCode;
                
                OnKeyDown?.Invoke(key);
                break;
            }
            // case WmKeyup:
            // {
            //     var vkCode = Marshal.ReadInt32(lParam);
            //     var key = (Keys)vkCode;
            //     Console.WriteLine("Global Key Up: " + key);
            //     break;
            // }
        }

        return CallNextHookEx(_hookId, nCode, wParam, lParam);
    }


    public void Dispose()
    {
        UnhookWindowsHookEx(_hookId);
    }
}