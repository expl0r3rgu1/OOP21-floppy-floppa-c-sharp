using System;
using System.Drawing;

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
