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

	public Shop()
    {
		_coins = 0;
		_skins = new List<PurchaseStatus<PricedSkin>>();
		_sceneries = new List<PurchaseStatus<PricedBackground>>();
		_skinInitialize = new List<string>
		{
			"Floppa", "Sogga", "Capibara", "Quokka", "Buding",
		};
		_backgroundInitialize = new List<string>
		{
			"Classic", "Beach", "Woods", "Space", "NeonCity",
		};

		_skinsNum = _skinInitialize.Count;
		_sceneriesNum = _backgroundInitialize.Count;

		_prices = new List<int>
		{
			0, 50, 100, 200, 500,
		};

		_savingsFile = new File(); //TODO

	}
}