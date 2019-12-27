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
        DateTime startTime = new DateTime();
        static string charDatabase = "1";
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

            DateTime start = new DateTime();

            int i = 0;
            while (true)
            {
                Thread t = new Thread(new ThreadStart(ThreadLine));
                t.Start();
                Thread.Sleep(100);
                i++;
                if(i> 100) { 
                    Thread.Sleep(100);
                    Thread cc = new Thread(new ThreadStart(CleanConsole));
                    cc.Start();
                    i = 0;
                }
            }

            Console.ReadKey();
        }
        static void CleanConsole()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for (int i = 0; i < width; i+=3)
            {
                for(int j =0; j< height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("   ");
                }
            }
        }
        static void ThreadLine(){

            Random rnd = new Random();

            int posX = rnd.Next(0, Console.WindowWidth);
            int posY = (rnd.Next(0, Console.WindowHeight) /8)-1;

            string head = OneChar();

            int height = rnd.Next(5, 45);

            int timeToClean = rnd.Next(1500, 2500);

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
                Console.Write("       ");

                Thread.Sleep(50);
            }
        }

    }
}
