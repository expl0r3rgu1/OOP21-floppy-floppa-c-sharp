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

		/// <param name="x">the x coordinate on the map</param>
		/// <param name="y">the y coordinate on the map</param>
		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>
		/// Getter of the x coordinate
		/// </summary>
		/// <returns>the current x coordinate</returns>
		public int GetX() => x;

		/// <summary>
		/// Setter of the x coordinate
		/// </summary>
		/// <param name="x">the new x coordinate</param>
		public void SetX(int x) => this.x = x;

		/// <summary>
		/// Getter of the y coordinate
		/// </summary>
		/// <returns>the current y coordinate</returns>
		public int GetY() => y;

		/// <summary>
		/// Setter of the y coordinate
		/// </summary>
		/// <param name="y">the new y coordinate</param>
		public void SetY(int y) => this.y = y;

		/// <inheritdoc />
		public override bool Equals(object obj)
        {
            return obj is Position position &&
                   x == position.x &&
                   y == position.y;
        }

		/// <inheritdoc />
		public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}