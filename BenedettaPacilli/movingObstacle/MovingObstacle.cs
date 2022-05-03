using System.Timers;
using System.Windows.Forms;
using Utilities;
using NUnit.Framework;
using System.Drawing;

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
		public MovingObstacle(Position position, Skin skin) : base(position)
		{
			this.skin = skin;

			timer = new Timer(1000);
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		}

		/// <summary>
		/// The main method to update the MovingObstacle position, in the map, through time
		/// </summary>
		private void UpdatePosition()
		{
			Position = new Position(Position.X - 3 * movingFactor, Position.Y + direction * movingFactor);
		}

		/// <inheritdoc/>
		public override void Animate(RibbonElementPaintEventArgs ribbonElementPaintEventArgs)
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
		public override bool Equals(object obj)
		{
			MovingObstacle other = (MovingObstacle)obj;
			return base.Equals(other) && this.Skin == other.Skin;
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[TestFixture]
		public class TestMovingObstacle
        {
			private const Image imagePlaceholder = null;
			private const int movingFactor = 2;
			private int direction = -1;
			private static readonly Position POSITION = new Position(1920, (int) (1080 / 2));
			private readonly Position HALFWAY_POSITION = new Position((int) (1920 / 2), (int) (1080 / 2));
			private readonly Skin SKIN = new Skin("name", imagePlaceholder, POSITION.X, POSITION.Y);

			/// <summary>
			/// Check if the moving pattern of the moving obstacle works correctly
			/// </summary>
			[Test]
			public void MovingObstacleMovement()
			{
				MovingObstacle movingObstacle = new MovingObstacle(POSITION, SKIN);
				movingObstacle.UpdatePosition();

				Assert.IsTrue(movingObstacle.Position.X == (POSITION.X - 3 * movingFactor));
				Assert.IsTrue(movingObstacle.Position.Y == (POSITION.Y + direction * movingFactor));

				MovingObstacle movingObstacle1 = new MovingObstacle(HALFWAY_POSITION, SKIN);
				movingObstacle1.UpdatePosition();

				Assert.IsTrue(movingObstacle1.Position.X == (HALFWAY_POSITION.X - 3 * movingFactor));
				Assert.IsTrue(movingObstacle.Position.Y == (HALFWAY_POSITION.Y + direction * movingFactor));
			}
		}

	}
}