using System.Drawing;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola
{
	/// <summary>
	/// A class that represents the entity appearance on the map
	/// </summary>
	public class Skin
	{
		private string _name;
		private Image _image;
		private int _width;
		private int _height;

		/// <param name="name">the name of the skin</param>
		/// <param name="image">the image of the skin</param>
		/// <param name="width">the width of the skin</param>
		/// <param name="height">the height of the skin</param>
		public Skin(string name, Image image, int width, int height)
		{
			_name = name;
			_image = image;
			_width = width;
			_height = height;
		}

		/// <summary>
		/// Getter of the skin name
		/// </summary>
		/// <returns>the name of the skin</returns>
		public string GetName() => _name;

		/// <summary>
		/// Setter of the skin name
		/// </summary>
		/// <param name="name">name the new name of the skin</param>
		public void SetName(string name) => _name = name;

		/// <summary>
		/// Getter of the skin image
		/// </summary>
		/// <returns>the image of the skin</returns>
		public Image GetImage() => _image;

		/// <summary>
		/// Setter of the skin image
		/// </summary>
		/// <param name="image">the new image of the skin</param>
		public void SetImage(Image image) => _image = image;

		/// <summary>
		/// Getter of the skin width
		/// </summary>
		/// <returns>the width of the skin</returns>
		public int GetWidth() => _width;

		/// <summary>
		/// Setter of the skin width
		/// </summary>
		/// <param name="width">the new width of the skin</param>
		public void SetWidth(int width) => _width = width;

		/// <summary>
		/// Getter of the skin height
		/// </summary>
		/// <returns>the height of the skin</returns>
		public int GetHeight() => _height;

		/// <summary>
		/// Setter of the skin height
		/// </summary>
		/// <param name="height">the new height of the skin</param>
		public void SetHeight(int height) => _height = height;
	}
}

