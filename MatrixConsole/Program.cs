using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixConsole
{

    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;



        DateTime startTime = new DateTime();
        static string charDatabase = "0123456789";
        static string OneChar()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, charDatabase.Length);
            return charDatabase[index].ToString(); ;
        }
        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //ShowWindow(ThisConsole, MAXIMIZE)
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            DateTime start = new DateTime();

            int i = 0;
            while (true)
            {
                Thread t = new Thread(new ThreadStart(ThreadLine));
                t.Start();
                Thread.Sleep(50);
                i++;
                if (i > 100)
                {

                }
                if (i == 250) {
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Thread cc = new Thread(new ThreadStart(() => CleanConsole(OneChar())));
                    cc.Start();
                }
                if (i > 300)
                {
                    Thread.Sleep(100);
                    Thread cc = new Thread(new ThreadStart(() => CleanConsole(" ")));
                    cc.Start();
                    i = 0;
                }
            }
        
            Console.ReadKey();
        }
        static void CleanConsole(string sign)
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for (int i = 0; i < width; i+=3)
            {
                for(int j =0; j< height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine(sign + sign + sign);
                }
            }
        }
        static void ThreadLine(){

            Random rnd = new Random();

            int posX = rnd.Next(0, Console.WindowWidth);
            int posY = (rnd.Next(0, Console.WindowHeight) /8)-1;

            string head = OneChar();

            int height = rnd.Next(5, 45);

            int timeToClean = rnd.Next(3500, 4500);

            for (int j = 2; j < height; j++)
            {
               if (j + posY > Console.WindowHeight || posX > Console.WindowWidth) 
                    break;
                Console.SetCursorPosition(posX, j + posY - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.Write(OneChar());
                
                Thread.Sleep(rnd.Next(2, 5));
                
                Console.SetCursorPosition(posX, j + posY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(head);

                Thread.Sleep(rnd.Next(2, 5));
            }
            Thread.Sleep(timeToClean);
            for(int i = 0; i< height; i++)
            {
                if (i + posY > Console.WindowHeight || posX > Console.WindowWidth || posX -3 < 0) break;

                Console.SetCursorPosition(posX-2 , i + posY+1);
                Console.Write("     ");

                Thread.Sleep(50);
            }
        }

    }
}
