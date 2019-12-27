using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixConsole
{
    class Program
    {
        DateTime dateTime = new DateTime();
        static string charDatabase = "01";
        static string OneChar()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, charDatabase.Length);
            return charDatabase[index].ToString(); ;
        }
        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            //int windowHeight = Console./2;
            //Console.SetWindowSize(windowWidth, windowHeight);
            //THREAD
            int i = 0;
            while (true)
            {
                i++;

                Random rnd = new Random();
                int posX = rnd.Next(0, Console.WindowWidth);
                int posY = rnd.Next(0, Console.WindowHeight) / 4;
                int temp = -2;
                Console.SetCursorPosition(posX, 0);
                for (int j = 0; j < rnd.Next(5,50); j++)
                {
                    
                    Console.SetCursorPosition(posX, j+posY);
                    Console.ForegroundColor = j <5 ? ConsoleColor.Green : ConsoleColor.DarkYellow;
                    Console.ForegroundColor = j >10 ? ConsoleColor.Yellow : ConsoleColor.Green;
                    Console.Write(OneChar());
                }
                //Console.ForegroundColor = ConsoleColor.Green;
                //Thread thread = new Thread();
                //thread.Start()
                //Console.SetCursorPosition(posX, posY);
                //Console.Write("1");
            }


            Console.ReadKey();
        }
        static void asss(){
            
        }

    }
}
