using System;
using System.Collections.Generic;
using System.Text;

namespace WCGApp
{
    class DataView
    {
       
        public static void ViewFile()
        {
            bool back = true;
            CarDataService cardView = new CarDataService();
            List<CarData> cardList = new List<CarData>();
            cardList = cardView.FileRead();
            while (back)
            {
                //=>User Menu
                Console.WriteLine("<<<==========================================================>>>");
                Console.WriteLine("==>Would you like to view all the data at once?");
                Console.WriteLine("==>Or would you like to view the data 1 card at a time?");
                Console.WriteLine("<<<==========================================================>>>\n");
                Console.Write("Please hit enter after selecting => <A>ll, <V>iew One at a time, go <B>ack: ");
                //=>Converts the input into the ability to read the option.
                var input = Console.ReadLine();
                input.ToUpper();
                Console.Clear();
                //=>PROCURES the entire list, removing the card text for a 'quick' list
                // Note: Attempted to convert the input to a single 'Char' and attempted to convert it to string
                // Attmpted to Uppercase it as well, C# isn't interpreting, ignoring it: I'll need to seek help how to pursue this.
                if (input == "A" || input == "a")
                {
                    Console.WriteLine("<<<==========================================================>>>");
                    Console.WriteLine("Name \t Type \t Card Color/Tribe \t Cost \t Attack \t Hit Points");
                    for (int x = 0; x < cardList.Count; x++)
                    {
                        //=>This switch changes the color of the text for each card, just to make things a little easier to identify.
                        switch (cardList[x].cardColor)
                        {
                            case "Burrom":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "Gelofon":
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case "Earth":
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case "Ariani":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case "Mooran":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "Grey Relic":
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                        }

                        Console.WriteLine(cardList[x].cardName + " \t " + cardList[x].cardType + " \t " + cardList[x].cardColor + " \t " + cardList[x].cardCost + " \t " + cardList[x].cardPower + " \t " + cardList[x].cardHP);
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n>> End of List");
                    Console.WriteLine(">> Press Any Key To go back to the Propmt.");
                    Console.ReadKey();
                    Console.Clear();
                }

                //PROCURES portions of the list; shows everything in digestable chunks.
                // I'll need to put this into it's own method.
                if (input == "V" || input == "v")
                {
                    CardByCard(cardList);
                }
                

                if (input == "B" || input == "b") {
                    Console.Clear();
                    back = false;
                }


            }

        }

        public static void CardByCard(List<CarData> cardList)
        {
            bool breakLoop = true;
            int temp = 0;
            while (breakLoop)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("<<<=========================Worlds Set View=========================>>>");
                // Changes the Card text like the mass list above.
                switch (cardList[temp].cardColor)
                {
                    case "Burrom":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Gelofon":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "Earth":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Ariani":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "Mooran":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Grey Relic":
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                }
                Console.WriteLine("\n " + cardList[temp].cardName + " \n Set: " + cardList[temp].cardSet + " \n Type: " + cardList[temp].cardType + " \n Tribe/Color: " + cardList[temp].cardColor + " \n Cost: " + cardList[temp].cardCost + " \n Power: " + cardList[temp].cardPower + "\n Life/Hit Points: " + cardList[temp].cardHP + "\n \n Card Text: \n" + cardList[temp].cardText + "\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("<<<=================================================================>>>");
                Console.WriteLine("Previous - Press[<-] || Advance - Press [->] || <B>ack");
                var usrInput = Console.ReadKey();
                Console.Clear();

                switch (usrInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        temp += 1;
                        if (temp >= cardList.Count)
                        {
                            temp = cardList.Count - 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        temp -= 1;
                        if (temp < 0)
                        {
                            temp = 0;
                        }
                        break;
                    case ConsoleKey.B:
                        breakLoop = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
