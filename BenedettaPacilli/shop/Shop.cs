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
	//private sealed List<PurchaseStatus<PricedSkin>> _skins;
	//private sealed List<PurchaseStatus<PricedBackground>> _sceneries;
	private sealed File _savingsFile;
}