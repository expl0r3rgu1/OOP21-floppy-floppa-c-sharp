using System.Timers;
using System.Windows.Forms;
using Utilities;

namespace ObstacleFactory {
	/// <summary>
	/// A class that implements an Obstacle that changes its position on the map
	/// </summary>
	public class MovingObstacle : Movable
	{
		private Timer timer;
		private readonly Skin skin;
		private int direction = -1;
		private const int movingFactor = 2;

		/// <summary>
		/// the MovingObstacle Skin
		/// </summary>
		public Skin Skin => skin;

		/// <param name="position"> the obstacle initial position</param>
		/// <param name="skin"> the obstacle Skin</param>
		public MovingObstacle(Position position, Skin skin):base(position)
		{
			skin = skin;

			timer = new Timer(1000);
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		}

		/// <summary>
		/// The main method to update the MovingObstacle position, in the map, through time
		/// </summary>
		private void UpdatePosition()
		{
			Position.X = Position.X - 3 * movingFactor;
			Position.Y = Position.Y + direction * movingFactor;
		}

		/// <inheritdoc/>
		private override Animate(RibbonElementPaintEventArgs ribbonElementPaintEventArgs)
		{
			ribbonElementPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y, skin.Width, skin.Height);

			UpdatePosition();
		}
	
		/// <summary>
		/// The action performed when the Timer's interval has elapsed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			direction = -direction;
			timer.Stop();
		}

		/// <inheritdoc/>
		public bool Equals(object obj)
		{
			MovingObstacle other = (MovingObstacle)obj;
			return base.Equals(other) && this.Skin = other.Skin;
		}

		/// <inheritdoc/>
		public int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}