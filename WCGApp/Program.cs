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
            bool done = true;

            // Header - Introducing the User to the program.
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("=");
                if (i == 15)
                {
                    Console.Write(">> Welcome to the 'Worlds LCG' Database << \n");
                }
            }
            
            // Main Loop - Waits for exit statement.
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

        /// <summary>
        /// Personal User Options
        /// ===========================================
        /// Just here to serve a simple function = Copy and paste the menu whenever and wherever I need it.
        /// </summary>
        public static void pUsrOptions()
        {
            Console.WriteLine("===>> Select an Option");
            Console.WriteLine("<C>heck the cards on file");
            Console.WriteLine("<D>one -> Quit this program");   
        }
    }
}
