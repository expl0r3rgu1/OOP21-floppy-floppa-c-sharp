using System;
using Utilities;
using System.Windows.Forms;

namespace ObstacleFactory
{
	/// <summary>
	/// A class that implements a fixed Obstacle
	/// </summary>
	public class FixedObstacle : Movable
	{
		private readonly Skin skin;
		public const int MovingFactor = 2;
        private readonly int space_between_pipes = 300;
        private readonly int screen_size_width = 1080;
        private readonly int screen_size_height = 980;

		/// <summary>
		/// The Skin of the entity
		/// </summary>
		public Skin Skin => skin;

		/// <param name="position">the obstacle initial Position</param>
		/// <param name="skin">the obstacle Skin</param>
		public FixedObstacle(Position position, Skin skin) : base(position)
		{
			this.skin = skin;
		}

		/// <summary>
		/// UpdatePosition is a method that as its name says updates the position, the X,
		/// of the fixedobstacle
		/// </summary>
		private void UpdatePosition()
		{
			Position.X = Position.X - MovingFactor;
			Position.Y = Position.Y;
		}

		/// <inheritdoc />
		public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
		{
			ribbonPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y + (int)space_between_pipes / 2, screen_size_width / 10, screen_size_height - (Position.Y + (int)space_between_pipes / 2));

			UpdatePosition();
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			FixedObstacle other = obj as FixedObstacle;

			if (other == null)
			{
				return false;
			}

			return base.Equals(obj) && skin.Equals(other.skin);
		}

		/// <inheritdoc />
		public override int GetHashCode() => base.GetHashCode();

	}

}
