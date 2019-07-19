using System;
using System.Collections.Generic;
using System.Text;

namespace WCGApp
{
    class DataView
    {

       // User File Manipulation
       // ======================================================
       // This setup is created to view and manipulate the file.
       // ======================================================

        public static void ViewEditFile()
        {
            //Setting up the Variables, priming.

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
                Console.Write("<A>ll, <V>iew One at a time, go <B>ack: ");

                //=>Converts the input into the ability to read the option.
                var input = Console.ReadKey();
                Console.Clear();

                //=>PROCURES the entire list, removing the card text for a 'quick' list
                // Note: Attempted to convert the input to a single 'Char' and attempted to convert it to string
                // Attmpted to Uppercase it as well, C# isn't interpreting, ignoring it: I'll need to seek help how to pursue this.
                if (input.Key == ConsoleKey.A)
                {
                    Console.WriteLine("<<<==========================================================>>>");
                    Console.WriteLine("Name \t Type \t Card Color/Tribe \t Cost \t Attack \t Hit Points\n");
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
                if (input.Key == ConsoleKey.V)
                {
                    CardByCard(cardList);
                }
                

                if (input.Key == ConsoleKey.B) {
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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("<<<======================================================Worlds Set View========================================>>>\n");

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
                // Writes for Single View.
                Console.WriteLine("\n " + cardList[temp].cardName + " \n Set: " + cardList[temp].cardSet + " \n Type: " + cardList[temp].cardType + " \n Tribe/Color: " + cardList[temp].cardColor + " \n Cost: " + cardList[temp].cardCost + " \n Power: " + cardList[temp].cardPower + "\n Life/Hit Points: " + cardList[temp].cardHP + "\n \n Card Text: \n" + cardList[temp].cardText + "\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("<<<=============================================================================================================>>>\n");

                //Complex Menu Selection - Changes based on how the view works
                Console.WriteLine("Previous - Press[<-] || <A>dd a card || <R>emove Card Displayed || <E>dit || Advance - Press [->] || <B>ack");
                var usrInput = Console.ReadKey();
                Console.Clear();
                switch (usrInput.Key)
                {
                    // Set's up the [→] Arrow Key to go through the data
                    case ConsoleKey.RightArrow:
                        temp += 1;
                        if (temp >= cardList.Count)
                        {
                            temp = cardList.Count - 1;
                        }
                        break;
                    // Set's up the [←] Arrow Key to go through the data
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

                    // Function, not a method, devoted to Adding to the Database.
                    case ConsoleKey.A:
                        while (true)
                        {
                            var newCard = new CarData();
                            Console.WriteLine(">>>>>>>>>>!!!Adding A New Card!!!<<<<<<<<<<");

                            // Sets New Card Name
                            Console.WriteLine("Name of the card: ");
                            string CardName = Console.ReadLine();

                            // Sets new Card Type, Relic, Unit or Skill
                            Console.WriteLine("\nIs this card a Skill, Unit or Relic?: ");
                            string CardType = Console.ReadLine();

                            // Sets the cost of the New Card
                            Console.WriteLine("\nHow much does it cost to play it?: ");
                            string CardCost = Console.ReadLine();

                            // Sets the Cards Strength
                            Console.WriteLine("\nHow much damage can it inflict?: ");
                            string CardPower = Console.ReadLine();

                            // Sets the New Cards Toughness
                            Console.WriteLine("\nHow much Punishment can it take?: ");
                            string CardHP = Console.ReadLine();

                            // Sets the Card Effects
                            Console.WriteLine("\nWhat can it do when it's in play?");
                            Console.WriteLine("Please Note: Do not use commas(',') as the medium is a .CSV");
                            Console.WriteLine("Any use of commas (',') will cause the propgram to misread the file");
                            string CardText = Console.ReadLine();

                            // Sets The Cards Color
                            Console.WriteLine("\nWhat tribe is this unit apart of?");
                            Console.WriteLine("->><E>arth, <B>urrom, <A>riani, <M>ooran, <G>elofon, <R>elic<<-");

                            // Prepares new card color
                            var colorInput = Console.ReadKey();
                            bool colorOption = true;
                            string CardColor = "";
                            while (colorOption) {
                                switch (colorInput.Key)
                                {
                                    case ConsoleKey.E:
                                        CardColor = "Earth";
                                        colorOption = false;
                                        break;
                                    case ConsoleKey.B:
                                        CardColor = "Burrom";
                                        colorOption = false;
                                        break;
                                    case ConsoleKey.A:
                                        CardColor = "Ariani";
                                        colorOption = false;
                                        break;
                                    case ConsoleKey.M:
                                        CardColor = "Mooran";
                                        colorOption = false;
                                        break;
                                    case ConsoleKey.G:
                                        CardColor = "Gelofon";
                                        colorOption = false;
                                        break;
                                    case ConsoleKey.R:
                                        CardColor = "Grey Relic";
                                        colorOption = false;
                                        break;
                                    default:
                                        break;
                                };
                            }

                            // Sets the set the card is from
                            Console.WriteLine("\nWhat set?: ");
                            string CardSet = Console.ReadLine();

                            // Final Confirmtion
                            Console.WriteLine("Reading Above, Are you sure you want to add this card? <Y>es, <B>ack; Any other key will restart this process");
                            var turnPoint = Console.ReadKey();


                            newCard.cardName = CardName;
                            newCard.cardType = CardType;
                            newCard.cardCost = CardCost;
                            newCard.cardPower = CardPower;
                            newCard.cardHP = CardHP;
                            newCard.cardText = CardText;
                            newCard.cardColor = CardColor;
                            newCard.cardSet = CardSet;

                            if (turnPoint.Key == ConsoleKey.Y)
                            {
                                Console.Clear();
                                cardList.Add(newCard);
                                CarDataService.FileWrite(cardList);
                                break;
                            }
                            Console.Clear();
                            if (turnPoint.Key == ConsoleKey.B)
                            {
                                break;
                            }
                        }
                        break;

                    // This section removes the currently viewed card.
                    case ConsoleKey.R:
                        Console.WriteLine("Are you sure? Once this is removed, it cannot be recovered <Y>es, any other key will quit the action.");
                        var deleteInput = Console.ReadKey();
                        if (deleteInput.Key == ConsoleKey.Y)
                        {
                            cardList.RemoveAt(temp);
                            CarDataService.FileWrite(cardList);
                            if (temp <= cardList.Count)
                            {
                                temp--;
                            }
                        }
                        break;

                    // This will edit the information on the currently viewed card.
                    case ConsoleKey.E:
                        Console.WriteLine("What do you want to Edit?");
                        Console.WriteLine("<N>ame, <T>ype, C<O>st, <P>ower, <H>it Points, T<E>xt, <C>olor, <S>et: ");
                        var editInput = Console.ReadKey();
                        Console.Clear();

                        switch (editInput.Key)
                        {
                            case ConsoleKey.N:
                                Console.WriteLine("Input a New Name: ");
                                cardList[temp].cardName = Console.ReadLine();
                                break;

                            case ConsoleKey.T:
                                Console.WriteLine("Input a New Card Type: ");
                                cardList[temp].cardType = Console.ReadLine();
                                break;

                            case ConsoleKey.O:
                                Console.WriteLine("Input a New Cost: ");
                                cardList[temp].cardCost = Console.ReadLine();
                                break;

                            case ConsoleKey.P:
                                Console.WriteLine("Input the New Attack: ");
                                cardList[temp].cardPower = Console.ReadLine();
                                break;

                            case ConsoleKey.H:
                                Console.WriteLine("Input the New Hit Points: ");
                                cardList[temp].cardHP = Console.ReadLine();
                                break;

                            case ConsoleKey.E:
                                Console.WriteLine("Input a New Card Effect, do not include Commas (','): ");
                                cardList[temp].cardText = Console.ReadLine();
                                break;

                            case ConsoleKey.S:
                                Console.WriteLine("Re-Write the Card Set: ");
                                cardList[temp].cardSet = Console.ReadLine();
                                break;

                            case ConsoleKey.C:
                                var colorInput = Console.ReadKey();
                                bool colorOption = true;
                                string CardColor = "";
                                while (colorOption)
                                {
                                    Console.WriteLine("What is the new Color?");
                                    Console.WriteLine("->><E>arth, <B>urrom, <A>riani, <M>ooran, <G>elofon, <R>elic<<-");
                                    switch (colorInput.Key)
                                    {
                                        case ConsoleKey.E:
                                            CardColor = "Earth";
                                            colorOption = false;
                                            break;
                                        case ConsoleKey.B:
                                            CardColor = "Burrom";
                                            colorOption = false;
                                            break;
                                        case ConsoleKey.A:
                                            CardColor = "Ariani";
                                            colorOption = false;
                                            break;
                                        case ConsoleKey.M:
                                            CardColor = "Mooran";
                                            colorOption = false;
                                            break;
                                        case ConsoleKey.G:
                                            CardColor = "Gelofon";
                                            colorOption = false;
                                            break;
                                        case ConsoleKey.R:
                                            CardColor = "Grey Relic";
                                            colorOption = false;
                                            break;
                                        default:
                                            break;
                                    };
                                }
                                cardList[temp].cardColor = CardColor;
                                break;

                            default:
                                break;
                        }
                        CarDataService.FileWrite(cardList);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
