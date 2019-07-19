using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace WCGApp
{
    class CarDataService
    {
        public CarDataService()
        {

        }

        // Card Data Service
        // ====================================================================
        // File•Read:
        // The method below pulls the CSV file, reads it and will return a list
        // of all the content's in the file.
        // ====================================================================
        // File•Write:
        // This Method writes back out to the file any data changes.
        // Everything from minor changes to new cards.
        // ====================================================================

        public List<CarData> FileRead()
        {
            List<CarData> cardData = new List<CarData>();
            string DataDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (var reader = new StreamReader(DataDirectory + "Worlds_ Card Library Data Table.csv"))
            {
                string DataRet;

                while ((DataRet = reader.ReadLine()) != null)
                {
                    var listItem = new CarData();
                    var Line = DataRet.Split(',');
                    // Variables to set each value of the items in the list
                    listItem.cardName = Line[0];
                    listItem.cardType = Line[1];
                    listItem.cardCost = Line[2];
                    listItem.cardPower = Line[3];
                    listItem.cardHP = Line[4];
                    listItem.cardText = Line[5];
                    listItem.cardColor = Line[6];
                    listItem.cardSet = Line[7];

                    cardData.Add(listItem); //Item in the current line gets stored.

                }

            }

            return cardData; //Returns EVERYTHING IN THE FILE!!!
        }

        // Writes new stuff back to the file.
        public static void FileWrite(List<CarData>cardList){

            string DataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            using (var sWriter = new StreamWriter(DataDirectory + "Worlds_ Card Library Data Table.csv"))
            {
                foreach (CarData cd in cardList)
                {
                    sWriter.WriteLine(cd.cardName + "," + cd.cardType + "," + cd.cardCost + "," + cd.cardPower + "," + cd.cardHP + "," + cd.cardText + "," + cd.cardColor + "," + cd.cardSet);
                }
            }
        }
    }
}
