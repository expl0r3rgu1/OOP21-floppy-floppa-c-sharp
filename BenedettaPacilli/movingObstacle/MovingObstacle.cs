using System.Timers;
using System.Drawing;

public class MovingObstacle
{
	private Timer _timer;
	private Image _skin;
	private int _x;
	private int _y;
	private int _direction = -1;

	public MovingObstacle(int x, int y, Image skin) //Position and Skin
	{
		_x = x;
		_y = y;
		_skin = skin;

		_timer = new Timer
		{
			Interval = 1000
		};
		_timer.Start;
	}

	public GetSkin()
    {
		return _skin;
    }
}