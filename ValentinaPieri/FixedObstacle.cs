using System;

namespace ObstacleFactory
{
	public class FixedObstacle
	{
		private Image _skin;
		private int _x;
		private int _y;
		public const int MovingFactor = 2;

		public FixedObstacle(int x, int y, Image skin)
		{
			_x = x;
			_y = y;
			_skin = skin;
		}

		public GetSkin() => _skin;

		private void updatePosition()
		{
			_x = _x - MovingFactor;
			_y = _y;
		}

		public override bool equals(object obj)
		{
			FixedObstacle other = (FixedObstacle)obj;

			if (other == null)
			{
				return false;
			}

			return _x.Equals(other._x) & _y.Equals(other._y) & _skin.Equals(other.GetSkin);
		}

		public override int GetHashCode() => base.GetHashCode();
	}

}
