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
            //int windowHeight = Console./2;
            //Console.SetWindowSize(windowWidth, windowHeight);
            //THREAD
            //for (int i = 0; i <10; i++)
            while (true)
            {
                Thread t = new Thread(new ThreadStart(ThreadLine));
                t.Start();
                Thread.Sleep(300 );
            }

            Console.ReadKey();
        }
        static void ThreadLine(){

            Random rnd = new Random();

            int posX = rnd.Next(0, Console.WindowWidth);
            int posY = (rnd.Next(0, Console.WindowHeight) /8)-1;

            string head = OneChar();

            int height = rnd.Next(5, 45);

            int timeToClean = rnd.Next(4500, 5500);

            for (int j = 2; j < height; j++)
            {
               if (j + posY > Console.WindowHeight || posX > Console.WindowWidth) 
                    break;
                Console.SetCursorPosition(posX, j + posY - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(OneChar());
                
                Thread.Sleep(1);
                
                Console.SetCursorPosition(posX, j + posY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(head);

                Thread.Sleep(50);
            }
            Thread.Sleep(timeToClean);
            for(int i = 0; i< height; i++)
            {
                if (i + posY > Console.WindowHeight || posX > Console.WindowWidth) break;

                Console.SetCursorPosition(posX, i + posY+1);
                Console.Write(" ");

                Thread.Sleep(50);
            }
        }

    }
}
