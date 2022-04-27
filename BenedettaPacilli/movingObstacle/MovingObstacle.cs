using System.Timers;
using System.Drawing;
using System;

public class MovingObstacle
{
	private Timer _timer;
	private Image _skin;
	private int _x;
	private int _y;
	private int _direction = -1;
	public const int MovingFactor = 2; //(int) Math.floor(SCREEN_SIZE.getWidth() / (double)1000) * 2;

    public Image Skin { get => _skin; set => _skin = value; }

    public MovingObstacle(int x, int y, Image skin) //Position and Skin
	{
		_x = x;
		_y = y;
		Skin = skin;

		_timer = new Timer
		{
			Interval = 1000
		};
		_timer.Start;
	}

	private void UpdatePosition()
    {
		_x = _x - 3 * MovingFactor;
		_y = _y + _direction * MovingFactor;
    }

    public override bool Equals(object obj)
    {
		MovingObstacle other = (MovingObstacle)obj;
        return this._x == other._x & this._y == other._y & this.Skin = other.Skin;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}