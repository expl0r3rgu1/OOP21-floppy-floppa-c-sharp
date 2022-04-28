using Utilities;
using System.Timers;
using StateChanger_Malus;
using System.Windows.Forms;

namespace StateChanger_Malus
{
	/// <summary>
	/// A class that extends Malus class and implements an entity that makes appear a
	/// stain on the screen, blocking the players vision of parts of the screen, 
	/// every time they hit this malus
	/// </summary>
	public class BlackStain : Malus
	{
		private bool collided = false;
		private readonly Timer timer;
		private const int MovingFactor = 2;
		private readonly int skin_dimension = 50;
		private readonly int space_between_pipes = 300;
		private readonly int screen_size_width = 1080;
		private readonly int screen_size_height = 980;

		/// <param name="position">the BlackStain initial Position</param>
		/// <param name="skin">the BlackStain Skin</param>
		public BlackStain(Position position, Skin skin) : base(position, skin)
        {
			timer = new Timer(300);
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		}

		/// <inheritdoc />
		public override void ChangeState()
		{
			timer.Start();
			this.collided = true;
            Position.X = Position.X - skin_dimension;
			Position.Y = Position.Y;
		}

		/// <summary>
		/// The method gives the BlackStain malus a new Position that leaves the Y
		/// position unchanged, while the X position decreases so that the object moves
		/// from right to left
		/// </summary>
		private void UpdatePositionX()
		{
			Position.X = Position.X - 3 * MovingFactor;
			Position.Y = Position.Y;
		}

		/// <inheritdoc />
		public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
		{
			ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

			UpdatePositionX();

			if (collided)
			{
				ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, 0, 0, screen_size_width, screen_size_height);
			}
		}

		/// <summary>
		/// OnTimedEvent stops the timer
		/// <summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			this.collided = false;
			this.timer.Stop();
		}

	}
}
