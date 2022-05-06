using System;

namespace Utilities
{
	/// <summary>
	///  A class that implements an object to keep track of the position of the
	///  various entities on the map
	/// </summary>
	public class Position
	{
		private int x;
		private int y;

		/// <summary>
		/// The x coordinate
		/// </summary>
        public int X { get => x; set => x = value; }
		/// <summary>
		/// The y coordinate
		/// </summary>
        public int Y { get => y; set => y = value; }

        /// <param name="x">the x coordinate on the map</param>
        /// <param name="y">the y coordinate on the map</param>
        public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <inheritdoc />
		public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   this.x == position.X &&
                   this.y == position.Y;
        }

		/// <inheritdoc />
		public override int GetHashCode()
        {
            return HashCode.Combine(this.x, this.y);
        }
    }
}
