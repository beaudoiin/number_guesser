using System;
using System.Runtime.InteropServices;

class Program
{
    const int STD_OUTPUT_HANDLE = -11;
    const int ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    [DllImport("kernel32.dll")]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll")]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int lpMode);

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, int dwMode);

    static bool EnableAnsi()
    {
        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        if (!GetConsoleMode(handle, out int mode))
            return false;

        return SetConsoleMode(handle, mode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);
    }

    static void Main()
    {
        bool ansiOk = EnableAnsi();

        if (ansiOk)
        {
            Console.WriteLine("\x1b[32mColors enabled\x1b[0m");
        }
        else
        {
            Console.WriteLine("Colors not supported on this system.");
        }

        // Example usage
        Print("Hello player", ansiOk);
    }

    static void Print(string text, bool ansi)
    {
        if (ansi)
            Console.WriteLine($"\x1b[36m{text}\x1b[0m");
        else
            Console.WriteLine(text);
    }
}
