using System.Timers;

namespace ObstacleFactory {
public class MovingObstacle : Movable
{
	private Timer timer;
	private Skin skin;
	private int direction = -1;
	private const int movingFactor = 2;

    public Skin Skin { get => skin; set => skin = value; }

    public MovingObstacle(Position position, Image skin):base(position)
	{
		skin = skin;

		timer = new Timer
		{
			Interval = 1000
		};
		timer.Start;
	}

	private void UpdatePosition()
    {
		Position.X = Position.X - 3 * movingFactor;
		Position.Y = Position.Y + direction * movingFactor;
    }

	private override Animate(RibbonElementPaintEventArgs ribbonElementPaintEventArgs)
	{
		ribbonElementPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y, skin.Width, skin.Height);

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
        return base.Equals(other) && this.skin = other.skin;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
}