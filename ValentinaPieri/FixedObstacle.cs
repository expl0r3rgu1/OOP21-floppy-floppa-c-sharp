using System;

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

	public GetSkin() => skin;

	private void updatePosition()
	{
		_x = _x - MovingFactor;
		_y = _y;
	}

	public override bool equals(object obj)
	{
		FixedObstacle other = (FixedObstacle)obj;
		return this._x == other._x & this._y == other._y & this._skin = other._skin;
	}

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
