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
            CarDataService cardEdit = new CarDataService(); 
            
            // Header - Introducing the User to the program.
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("=");
                if (i == 15)
                {
                    Console.Write(">> Welcome to the 'Worlds LCG' Database <<");
                }
            }
            Console.WriteLine("");
            
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
            }
        }

        public static void pUsrOptions()
        {
            // Just here to serve a simple function = Copy and paste the menu whenever and wherever I need it.
            Console.WriteLine("===>> Select an Option");
            Console.WriteLine("<C>heck the database");
            Console.WriteLine("<D>one -> Quit this program");
            
        }
    }
}
