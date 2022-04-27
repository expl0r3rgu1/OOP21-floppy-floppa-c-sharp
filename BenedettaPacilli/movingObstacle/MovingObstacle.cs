using System.Timers;

namespace ObstacleFactory {
public class MovingObstacle : Movable
{
	private Timer _timer;
	private Skin _skin;
	private int _direction = -1;
	private const int _movingFactor = 2;

    public Skin Skin { get => _skin; set => _skin = value; }

    public MovingObstacle(Position position, Image skin):base(position)
	{
		_skin = skin;

		_timer = new Timer
		{
			Interval = 1000
		};
		_timer.Start;
	}

	private void UpdatePosition()
    {
		Position.X = Position.X - 3 * _movingFactor;
		Position.Y = Position.Y + _direction * _movingFactor;
    }

	private override Animate(RibbonElementPaintEventArgs ribbonElementPaintEventArgs)
	{
		ribbonElementPaintEventArgs.Graphics.DrawImage(_skin.Image, Position.X, Position.Y, _skin.Width, _skin.Height);

		UpdatePosition();
	}
	
	//TODO
	/*@Override
	public void actionPerformed(ActionEvent e) {
		this.direction = -this.direction;
	}*/

    public override bool Equals(object obj)
    {
		MovingObstacle other = (MovingObstacle)obj;
        return base.Equals(other) && this._skin = other._skin;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
}