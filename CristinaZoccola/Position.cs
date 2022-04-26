using System;

namespace OOP21-floppy-floppa-c-sharp.CristinaZoccola
{
	/// <summary>
	///  A class that implements an object to keep track of the position of the
	///  various entities on the map
	/// </summary>
	public class Position
	{
		private int _x;
		private int _y;

		/// <param name="x">the x coordinate on the map</param>
		/// <param name="y">the y coordinate on the map</param>
		public Position(int x, int y)
		{
			_x = x;
			_y = y;
		}

		/// <summary>
		/// Getter of the x coordinate
		/// </summary>
		/// <returns>the current x coordinate</returns>
		public int GetX() => _x;

		/// <summary>
		/// Setter of the x coordinate
		/// </summary>
		/// <param name="x">the new x coordinate</param>
		public void SetX(int x) => _x = x;

		/// <summary>
		/// Getter of the y coordinate
		/// </summary>
		/// <returns>the current y coordinate</returns>
		public int GetY() => _y;

		/// <summary>
		/// Setter of the y coordinate
		/// </summary>
		/// <param name="y">the new y coordinate</param>
		public void SetY(int y) => _y = y;

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			Position other = (Position)obj;

			if (other == null)
			{
				return false;
			}

			return _x == other.GetX && _y == other.GetY;

		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	}
}