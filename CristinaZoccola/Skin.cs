using System;
using System.Collections.Generic;
using System.Drawing;

namespace Utilities
{
	/// <summary>
	/// A class that represents the entity appearance on the map
	/// </summary>
	public class Skin
	{
		private string name;
		private Image image;
		private int width;
		private int height;

		/// <summary>
		/// The name of the skin
		/// </summary>
        public string Name { get => name; set => name = value; }
		/// <summary>
		/// The image of the skin
		/// </summary>
        public Image Image { get => image; set => image = value; }
		/// <summary>
		/// The width of the skin
		/// </summary>
        public int Width { get => width; set => width = value; }
		/// <summary>
		/// The height of the skin
		/// </summary>
        public int Height { get => height; set => height = value; }

        /// <param name="name">the name of the skin</param>
        /// <param name="image">the image of the skin</param>
        /// <param name="width">the width of the skin</param>
        /// <param name="height">the height of the skin</param>
        public Skin(string name, Image image, int width, int height)
		{
			Name = name;
			Image = image;
			Width = width;
			Height = height;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
        {
            return obj is Skin skin &&
                   Name == skin.Name &&
                   EqualityComparer<Image>.Default.Equals(Image, skin.Image) &&
                   Width == skin.Width &&
                   Height == skin.Height;
        }

		/// <inheritdoc />
		public override int GetHashCode()
        {
            return HashCode.Combine(Name, Image, Width, Height);
        }
    }
}

