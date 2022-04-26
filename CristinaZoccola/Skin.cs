using System.Drawing;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola
{
	public class Skin
	{
		private string _name;
		private Image _image;
		private int _width;
		private int _height;

		public Skin(string name, Image image, int width, int height)
		{
			_name = name;
			_image = image;
			_width = width;
			_height = height;
		}

		public string GetName() => _name;

		public void SetName(string name) => _name = name;

		public Image GetImage() => _image;

		public void SetImage(Image image) => _image = image;

		public int GetWidth() => _width;

		public void SetWidth(int width) => _width = width;

		public int GetHeight() => _height;

		public void SetHeight(int height) => _height = height;
	}
}

