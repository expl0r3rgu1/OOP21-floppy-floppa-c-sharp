using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System;

namespace ShopSpace
{
    /// <summary>
    /// A class that keeps track of the items' current purchase status and that has
    /// methods to purchase the items
    /// </summary>
    public class Shop
    {
        private readonly int skinsNum;
        private readonly int sceneriesNum;
        private int coins;
        private const string savingsFileName = "savings";
        private readonly List<string> skinInitialize;
        private readonly List<string> backgroundInitialize;
        private readonly List<int> prices;
        private readonly List<PurchaseStatus<PricedSkin>> skins;
        private readonly List<PurchaseStatus<PricedBackground>> sceneries;
        private const Image imagePlaceholder = null;

        /// <summary>
        /// Can return the current coins amount or set a new amount for the coins field
        /// </summary>
        public int Coins { get => coins; set => coins = (value < 0) ? 0 : value; }

        /// <summary>
        /// Returns the list of purchase statuses of skins
        /// </summary>
        public List<PurchaseStatus<PricedSkin>> Skins => skins;

        /// <summary>
        /// Returns the list of purchase statuses of backgrounds
        /// </summary>
        public List<PurchaseStatus<PricedBackground>> Sceneries => sceneries;

        /// <summary>
        /// Returns the number of Skin objects
        /// </summary>
        public int SkinsNum => skinsNum;

        /// <summary>
        /// Returns the number of Background objects
        /// </summary>
        public int SceneriesNum => sceneriesNum;

        public Shop()
        {
            coins = 0;
            skins = new List<PurchaseStatus<PricedSkin>>();
            sceneries = new List<PurchaseStatus<PricedBackground>>();
            skinInitialize = new List<string>
            {
                "Floppa", "Sogga", "Capibara", "Quokka", "Buding",
            };
            backgroundInitialize = new List<string>
            {
                "Classic", "Beach", "Woods", "Space", "NeonCity",
            };

            skinsNum = skinInitialize.Count;
            sceneriesNum = backgroundInitialize.Count;

            prices = new List<int>
            {
                0, 50, 100, 200, 500,
            };

		    File.Create(savingsFileName);

            GetFileInfo();
        }

        /// <summary>
        /// Depending on the class of the parameter, the method passes, to another
        /// method, the parameter object together with the corresponding list of purchase 
        /// statuses
        /// </summary>
        /// <param name="o"> the object to be purchased</param>
        /// <returns> true if the given object gets purchased, false otherwise</returns>
        public bool Buy(object o)
        {
            if (o.GetType().Equals(PricedSkin.getType()))
            {
                return FindAndBuySkins(o, Skins);
            }
            else
            {
                return FindAndBuySceneries(o, Sceneries);
            }
        }

        /// <summary>
        ///  Finds the Object o in the List list and, if the current coins are enough and 
        ///  the item hasn't been previously purchased, it purchases it
        /// </summary>
        /// <param name="o"> the object to be purchased</param>
        /// <param name="purchaseStatusList"> List of purchase statuses of PricedSkin items</param>
        /// <returns> true if the given object gets purchased, false otherwise</returns>
        private bool FindAndBuySkins(object o, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
        {
            bool state = false;
            foreach (var status in purchaseStatusList)
            {
                if (status.Item.Equals(o))
                {
                    if (!status.Purchased && status.Item.Price <= coins)
                    {
                        status.Purchased = true;
                        coins = coins - status.Item.Price;
                        state = true;
                        break;
                    }
                }
            }
            return state;
        }

        /// <summary>
        /// Finds the Object o in the List list and, if the current coins are enough and 
        /// the item hasn't been previously purchased, it purchases it
        /// </summary>
        /// <param name="o"> the object to be purchased</param>
        /// <param name="purchaseStatusList"> List of purchase statuses of PricedBackground items</param>
        /// <returns> true if the given object gets purchased, false otherwise</returns>
        private bool FindAndBuySceneries(object o, List<PurchaseStatus<PricedBackground>> purchaseStatusList)
        {
            bool state = false;
            foreach (var status in purchaseStatusList)
            {
                if (status.Item.Equals(o))
                {
                    if (!status.Purchased && status.Item.Price <= coins)
                    {
                        status.Purchased = true;
                        coins = coins - status.Item.Price;
                        state = true;
                        break;
                    }
                }
            }
            return state;
        }

        /// <summary>
        /// Through a Scanner, the method reads the savings file to get the coins amount, 
        /// the initial purchase status of all skins and sceneries
        /// </summary>
        private void GetFileInfo()
        {
            StreamReader shopStreamReader = new StreamReader(savingsFileName);

            int counter = 0;
            string line = string.Empty;
            while ((line = shopStreamReader.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    coins = Int32.Parse(line);
                }
                else if (counter == 1)
                {
				    GetSkinsInfo(line, Skins);
                }
                else if (counter == 2)
                {
				    GetSceneriesInfo(line, Sceneries);
                    break;
                }

                counter++;
            }

            shopStreamReader.Close();
        }

        /// <summary>
        /// Creates skinsNum PurchaseStatus of PricedSkin objects and initializes them, 
        /// checks the line, word by word, to get the current PurchaseStatus
        /// </summary>
        /// <param name="line"> one line of the savings file</param>
        /// <param name="purchaseStatusList"> List of purchase statuses of PricedSkin items</param>
        private void GetSkinsInfo(string line, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
        {
            string[] lineWords = line.Split(",");

            for (int i = 0; i < SkinsNum; i++)
            {
                PurchaseStatus<PricedSkin> purchaseStatus = new PurchaseStatus<PricedSkin>(
				    new PricedSkin(skinInitialize[i], imagePlaceholder, 100, 100, prices[i]), false);
        
			    if(lineWords[i].Equals("1"))
			    {
				    purchaseStatus.Purchased = true;
			    }
		    
			    purchaseStatusList.Add(purchaseStatus);
		    }
        }

        /// <summary>
        /// Creates sceneriesNum PurchaseStatus of PricedBackground objects and 
        /// initializes them, checks the line, word by word, to get the current 
        /// PurchaseStatus
        /// </summary>
        /// <param name="line"> one line of the savings file</param>
        /// <param name="purchaseStatusList"> List of purchase statuses of PricedBackground items</param>
        private void GetSceneriesInfo(string line, List<PurchaseStatus<PricedBackground>> purchaseStatusList)
        {

            string[] lineWords = line.Split(",");

            for (int i = 0; i < SceneriesNum; i++)
            {
                PurchaseStatus<PricedBackground> purchaseStatus = new PurchaseStatus<PricedBackground>(
				    new PricedBackground(skinInitialize[i], imagePlaceholder, prices[i]), false);
        
			    if(lineWords[i].Equals("1"))
			    {
				    purchaseStatus.Purchased = true;
			    }
		
			    purchaseStatusList.Add(purchaseStatus);
		    }
        }

        /// <summary>
        ///  A method that updates the savings file at the end of a game
        /// </summary>
        public void FileUpdate()
	    {
		    string[] lines = File.ReadAllLines(savingsFileName);

		    if(Skins.Count != 0 && Sceneries.Count != 0)
		    {
			    lines[0] = coins.ToString();
			    lines[1] = OverwritePurchaseStatusLine(Skins);
			    lines[2] = OverwritePurchaseStatusLine(Sceneries);
		    }else 
		    {
			    lines[0] = "0";
			    lines[1] = "1,0,0,0,0";
			    lines[2] = "1,0,0,0,0";
		    }

		    File.WriteAllLines(savingsFileName, lines);
        }

        /// <summary>
        /// The method creates the new line of information for the savings file
        /// </summary>
        /// <typeparam name="X"> The items type</typeparam>
        /// <param name="purchaseStatusList"> List of purchase statuses of generic X items</param>
        /// <returns> the line that will be overwritten over an old line to update the 
        /// savings file</returns>
	    private string OverwritePurchaseStatusLine<X>(List<PurchaseStatus<X>> purchaseStatusList)
	    {
		    string line = "";

		    foreach (var purchaseStatus in purchaseStatusList)
		    {
			    if(purchaseStatus.Purchased)
			    {
				    if (string.IsNullOrEmpty(line))
				    {
					    line += "1";
				    }else
				    {
					    line += ",1";
				    }
			    } else
			    {
				    if (string.IsNullOrEmpty(line))
				    {
					    line += "0";
				    } else 
				    {
					    line += ",0";
				    }
			    }
		    }
		    return line;
	    }

        /// <summary>
        /// Used to clear data from the lists of Purchase Statuses.
        /// </summary>
        public void ClearSavings()
        {
            coins = 0;
            skins.ForEach(status => status.Purchased = false);
            skins[0].Purchased = true;

            sceneries.ForEach(status => status.Purchased = false);
            sceneries[0].Purchased = true;
        }
    }
}