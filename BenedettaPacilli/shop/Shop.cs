using System.Collections.Generic;
using System.IO;

public class Shop
{
	private int _skinsNum;
	private int _sceneriesNum;
	private int _coins;
	private sealed List<string> _skinInitialize;
	private sealed List<string> _backgroundInitialize;
	private sealed List<int> _prices;
	private sealed List<PurchaseStatus<PricedSkin>> _skins;
	private sealed List<PurchaseStatus<PricedBackground>> _sceneries;
	private sealed File _savingsFile;
	public int Coins { get => _coins; set => _coins = (value < 0) ? 0 : value; }
    public int SkinsNum { get => _skinsNum; set => _skinsNum = value; }
    public int SceneriesNum { get => _sceneriesNum; set => _sceneriesNum = value; }
    public List<PurchaseStatus<PricedSkin>> Skins { get => _skins; set => _skins = value; }
    public List<PurchaseStatus<PricedBackground>> Sceneries { get => _sceneries; set => _sceneries = value; }

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

		_savingsFile = new File(); //TODO

	}

   
}