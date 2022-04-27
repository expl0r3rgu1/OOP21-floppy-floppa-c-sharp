using System.Collections.Generic;
using System.IO;
using System.Drawing;

public class Shop
{
    private int _skinsNum;
    private int _sceneriesNum;
    private int _coins;
    private sealed const string _savingsFileName = "savings";
    private sealed List<string> _skinInitialize;
    private sealed List<string> _backgroundInitialize;
    private sealed List<int> _prices;
    private sealed List<PurchaseStatus<PricedSkin>> _skins;
    private sealed List<PurchaseStatus<PricedBackground>> _sceneries;
    private sealed const Image _imagePlaceholder = null;

    public int Coins { get => _coins; set => _coins = (value < 0) ? 0 : value; }

    public List<PricedSkin> GetSkins() { return _skins; }

    public List<PricedBackground> GetScenaries() { return _sceneries; }

    public int GetSkinsNum() { return _skinsNum; }

    public int GetBackgroundNum() { return _backgroundNum; }

    public Shop()
    {
        Coins = 0;
        Skins = new List<PurchaseStatus<PricedSkin>>();
        Sceneries = new List<PurchaseStatus<PricedBackground>>();
        _skinInitialize = new List<string>
        {
            "Floppa", "Sogga", "Capibara", "Quokka", "Buding",
        };
        _backgroundInitialize = new List<string>
        {
            "Classic", "Beach", "Woods", "Space", "NeonCity",
        };

        SkinsNum = _skinInitialize.Count;
        SceneriesNum = _backgroundInitialize.Count;

        _prices = new List<int>
        {
            0, 50, 100, 200, 500,
        };

        GetFileInfo();
    }

    public bool Buy(Object o)
    {
        if (o.getType().Name == "PricedSkin")
        {
            FindAndBuySkins(o, _skins);
        }
        else
        {
            FindAndBuySceneries(o, _sceneries);
        }
    }

    private bool FindAndBuySkins(Object o, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
    {
        bool state = false;
        foreach (var status in purchaseStatusList)
        {
            if (status.X.Equals(o))
            {
                if (!status.Purchased && status.X.Price <= _coins)
                {
                    status.Purchased = true;
                    _coins = _coins - status.X.Price;
                    state = true;
                    break;
                }
            }
        }
        return state;
    }

    private bool FindAndBuySceneries(Object o, List<PurchaseStatus<PricedBackground>> purchaseStatusList)
    {
        bool state = false;
        foreach (var status in purchaseStatusList)
        {
            if (status.X.Equals(o))
            {
                if (!status.Purchased && status.X.Price <= _coins)
                {
                    status.Purchased = true;
                    _coins = _coins - status.X.Price;
                    state = true;
                    break;
                }
            }
        }
        return state;
    }

    private void GetFileInfo()
    {
        StreamReader shopStreamReader = new StreamReader(_savingsFileName);

        int counter = 0;
        while ((line = shopStreamReader.ReadLine()) != null)
        {
            if (counter == 0)
            {
                _coins = line;
            }
            else if (counter == 1)
            {
				GetSkinsInfo(line, _skins);
            }
            else if (counter == 2)
            {
				GetSceneriesInfo(line, _sceneries);
                break;
            }

            counter++;
        }

        shopStreamReader.Close();
    }

    private void GetSkinsInfo(string line, List<PurchaseStatus<PricedSkin>> purchaseStatusList)
    {

        string[] lineWords = line.split(",");

        for (int i = 0; i < _skinsNum; i++)
        {
            PurchaseStatus<PricedSkin> purchaseStatus = new PurchaseStatus<PricedSkin>(
				new PricedSkin(_skinInitialize.get(i), _imagePlaceholder, 100, 100, _prices.get(i)), false);
        
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

        for (int i = 0; i < _backgroundNum; i++)
        {
            PurchaseStatus<PricedBackground> purchaseStatus = new PurchaseStatus<PricedBackground>(
				new PricedBackground(_skinInitialize.get(i), _imagePlaceholder, _prices.get(i)), false);
        
			if(lineWords[i].Equals("1"))
			{
				purchaseStatus.Purchased = true;
			}
		
			purchaseStatusList.add(purchaseStatus);
		}
    }
}