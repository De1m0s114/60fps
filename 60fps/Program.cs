using System;
using System.Diagnostics;
using System.Threading;

namespace _60fps
{
    public class Program
    {
        private static void olol() {
            if (i % 4 == 0)
            {
                Console.Write($"\r|");
                i++;
            }
            else if (i % 8 == 1)
            {
                i++;
                Console.Write($"\r/");
            }
            else if (i % 8 == 2)
            {
                i++;
                Console.Write($"\r―");
            }
            else if (i % 8 == 3)
            {
                i++;
                Console.Write($"\r\\");
            }
            else if (i % 8 == 5)
            {
                i++;
                Console.Write($"\r/");
            }
            else if (i % 8 == 6)
            {
                i++;
                Console.Write($"\r-");
            }
            else if (i % 8 == 7)
            {
                i++;
                Console.Write($"\r\\");
            }
        }
        public static int i = 0;
        public static void Main(string[] args)
        {
            var gameloop = new GameLoop(1);
            gameloop.Start(olol);
            

        }

    }
}


