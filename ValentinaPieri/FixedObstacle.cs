using System;
using System.Drawing;
using System.Windows.Forms;

namespace ObstacleFactory
{
    public class FixedObstacle
	{
		private readonly Skin skin;
		public const int MovingFactor = 2;

		public Skin Skin => skin;

		public FixedObstacle(Position position, Skin skin) : base(position)
		{
			this.skin = skin;
		}

		pprivate void UpdatePosition()
		{
			Position.X = Position.X - MovingFactor;
			Position.Y = Position.Y;
		}

		public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
		{
			int space_between_pipes = 300;
			int screen_size_width = 1080;
			int screen_size_height = 980;

			ribbonPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y + (int)space_between_pipes / 2, screen_size_width / 10, screen_size_height - (Position.Y + (int)space_between_pipes / 2));

			UpdatePosition();
		}

		public override bool equals(object obj)
		{
			FixedObstacle other = (FixedObstacle)obj;

			if (other == null)
			{
				return false;
			}

			return x.Equals(other.x) & y.Equals(other.y) & skin.Equals(other.GetSkin);
		}

		public override int GetHashCode() => base.GetHashCode();
	}

}
