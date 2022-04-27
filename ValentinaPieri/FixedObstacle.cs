using System;
using System.Drawing;

namespace ObstacleFactory
{
    public class FixedObstacle
	{
		private Image skin;
		private int x;
		private int y;
		public const int MovingFactor = 2;

		public FixedObstacle(int x, int y, Image skin)
		{
			x = x;
			y = y;
			skin = skin;
		}

        public GetSkin() => skin;

        private void updatePosition()
		{
			x = x - MovingFactor;
			y = y;
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
