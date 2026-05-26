using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_GameOfLife
{
    internal class Program
    {
        const int STD_OUTPUT_HANDLE = -11;
        const uint TMPF_TRUETYPE = 4;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public COORD dwFontSize;
            public int FontFamily;
            public int FontWeight;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string FaceName;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_MAXIMIZE = 3;

        static void Main(string[] args)
        {
            IntPtr consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);

            Console.WriteLine("Нажми любую клавишу...");
            Console.ReadKey(true);

            // Сохраняем текущие настройки
            CONSOLE_FONT_INFO_EX original = new CONSOLE_FONT_INFO_EX();
            original.cbSize = (uint)Marshal.SizeOf(original);

            GetCurrentConsoleFontEx(consoleHandle, false, ref original);

            // Создаем копию и меняем шрифт
            CONSOLE_FONT_INFO_EX newFont = original;

            newFont.FaceName = "Consolas";
            newFont.dwFontSize.X = 8;
            newFont.dwFontSize.Y = 6;

            SetCurrentConsoleFontEx(consoleHandle, false, ref newFont);


            IntPtr handle = GetConsoleWindow();

            if (handle != IntPtr.Zero)
            {
                ShowWindow(handle, SW_MAXIMIZE);
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);


            var gameEngine = new GameEngine
            (
                rows: 168,
                cols: 630,
                density: 2
            );

            bool isRunning = true;

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                isRunning = false;
            };

            while (isRunning)
            {
                Console.Title = gameEngine.CurrentGeneration.ToString();

                var field = gameEngine.GetCurrentGeneration();

                for (int y = 0; y < field.GetLength(1); y++)
                {
                    var str = new char[field.GetLength(0)];

                    for (int x = 0; x < field.GetLength(0); x++)
                    {
                        if (field[x, y])
                            str[x] = '#';
                        else
                            str[x] = ' ';
                    }
                    Console.WriteLine(str);
                }
                Console.SetCursorPosition(0, 0);
                gameEngine.NextGeneration();
            }

            Console.Clear();
            
            // Возвращаем исходные настройки
            SetCurrentConsoleFontEx(consoleHandle, false, ref original);
            Console.WriteLine("Игра остановлена. Настройки восстановлены.");
            Console.ReadLine();
        }
    }
}
