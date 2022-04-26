using System;

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
	}
}

