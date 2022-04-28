using System.Timers;
using System.Windows.Forms;
using Utilities;

namespace ObstacleFactory {
public class MovingObstacle : Movable
{
	private Timer timer;
	private Skin skin;
	private int direction = -1;
	private const int movingFactor = 2;

    public Skin Skin { get => skin; set => skin = value; }

    public MovingObstacle(Position position, Skin skin):base(position)
	{
		skin = skin;

		timer = new Timer(1000);
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
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
	
	private void OnTimedEvent(object sender, ElapsedEventArgs e)
	{
		direction = -direction;
		timer.Stop();
	}

    public bool Equals(object obj)
    {
		MovingObstacle other = (MovingObstacle)obj;
        return base.Equals(other) && this.skin = other.skin;
    }

    public int GetHashCode()
    {
        return base.GetHashCode();
    }

}
}