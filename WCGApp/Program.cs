using System;

namespace WCGApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            
            // Header - Introducing the User to the program.
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("=");
                if (i == 15)
                {
                    Console.Write(">> Welcome to the 'Worlds LCG' Database << \n");
                }
            }
            
            //Main Loop - Waits for exit statement.
            bool done = true;
            while (done)
            {
                pUsrOptions();
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.C:
                        Console.Clear();
                        DataView.ViewEditFile();
                        break;
                    case ConsoleKey.D:
                        done = false;
                        break;
                    default:
                        break;

                }
                Console.Clear();
            }

        }

        public static void pUsrOptions()
        {
            // Just here to serve a simple function = Copy and paste the menu whenever and wherever I need it.
            Console.WriteLine("===>> Select an Option");
            Console.WriteLine("<C>heck the cards on file");
            Console.WriteLine("<D>one -> Quit this program");
            
        }
    }
}
