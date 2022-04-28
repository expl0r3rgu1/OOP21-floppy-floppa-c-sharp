using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace ShopSpace
{

public class Shop
{
    private int skinsNum;
    private int sceneriesNum;
    private int coins;
    private const string savingsFileName = "savings";
    private readonly List<string> skinInitialize;
    private readonly List<string> backgroundInitialize;
    private readonly List<int> prices;
    private  List<PurchaseStatus<PricedSkin>> skins;
    private  List<PurchaseStatus<PricedBackground>> sceneries;
    private const Image imagePlaceholder = null;

    public int Coins { get => coins; set => coins = (value < 0) ? 0 : value; }

    public List<PurchaseStatus<PricedSkin>> Skins { get => skins; private set => skins = value; }

    public List<PurchaseStatus<PricedBackground>> Sceneries { get => sceneries; private set => sceneries = value; }

    public int SkinsNum { get => skinsNum; private set => skinsNum = value; }

    public int SceneriesNum { get => sceneriesNum; private set => sceneriesNum = value; }

    public Shop()
    {
        Coins = 0;
        Skins = new List<PurchaseStatus<PricedSkin>>();
        Sceneries = new List<PurchaseStatus<PricedBackground>>();
        skinInitialize = new List<string>
        {
            "Floppa", "Sogga", "Capibara", "Quokka", "Buding",
        };
        backgroundInitialize = new List<string>
        {
            "Classic", "Beach", "Woods", "Space", "NeonCity",
        };

        SkinsNum = skinInitialize.Count;
        SceneriesNum = backgroundInitialize.Count;

        prices = new List<int>
        {
            0, 50, 100, 200, 500,
        };

		File.Create(savingsFileName);

        GetFileInfo();
    }

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

    private bool FindAndBuySkins(object o, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
    {
        bool state = false;
        foreach (var status in purchaseStatusList)
        {
            if (status.X.Equals(o))
            {
                if (!status.Purchased && status.X.Price <= coins)
                {
                    status.Purchased = true;
                    coins = coins - status.X.Price;
                    state = true;
                    break;
                }
            }
        }
        return state;
    }

    private bool FindAndBuySceneries(object o, List<PurchaseStatus<PricedBackground>> purchaseStatusList)
    {
        bool state = false;
        foreach (var status in purchaseStatusList)
        {
            if (status.X.Equals(o))
            {
                if (!status.Purchased && status.X.Price <= coins)
                {
                    status.Purchased = true;
                    coins = coins - status.X.Price;
                    state = true;
                    break;
                }
            }
        }
        return state;
    }

    private void GetFileInfo()
    {
        StreamReader shopStreamReader = new StreamReader(savingsFileName);

        int counter = 0;
        while ((line = shopStreamReader.ReadLine()) != null)
        {
            if (counter == 0)
            {
                coins = line;
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

    private void GetSkinsInfo(string line, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
    {

        string[] lineWords = line.split(",");

        for (int i = 0; i < skinsNum; i++)
        {
            PurchaseStatus<PricedSkin> purchaseStatus = new PurchaseStatus<PricedSkin>(
				new PricedSkin(skinInitialize.get(i), imagePlaceholder, 100, 100, prices.get(i)), false);
        
			if(lineWords[i].Equals("1"))
			{
				purchaseStatus.Purchased = true;
			}
		
			purchaseStatusList.add(purchaseStatus);
		}
    }

	private void GetSceneriesInfo(string line, List<PurchaseStatus<PricedBackground>> purchaseStatusList)
    {

        string[] lineWords = line.split(",");

        for (int i = 0; i < sceneriesNum; i++)
        {
            PurchaseStatus<PricedBackground> purchaseStatus = new PurchaseStatus<PricedBackground>(
				new PricedBackground(skinInitialize.get(i), imagePlaceholder, prices.get(i)), false);
        
			if(lineWords[i].Equals("1"))
			{
				purchaseStatus.Purchased = true;
			}
		
			purchaseStatusList.add(purchaseStatus);
		}
    }
	
	public void FileUpdate()
	{
		string[] lines = File.ReadAllLines(savings);

		if(!skins.isEmpty() && !sceneries.isEmpty())
		{
			lines[0] = coins;
			lines[1] = OverwritePurchaseStatusLine(skins);
			lines[2] = OverwritePurchaseStatusLine(sceneries);
		}else 
		{
			lines[0] = "0";
			lines[1] = "1,0,0,0,0";
			lines[2] = "1,0,0,0,0";
		}

		File.WriteAllLines(savings, lines);
	}

	private string OverwritePurchaseStatusLine(List<PurchaseStatus<X>> purchaseStatusList)
	{
		string line = "";

		foreach (var purchaseStatus in purchaseStatusList)
		{
			if(purchaseStatus.Purchased)
			{
				if (line.isEmpty())
				{
					line += "1";
				}else
				{
					line += ",1";
				}
			} else
			{
				if (line.isEmpty())
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
}

}