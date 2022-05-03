using Utilities;
using System.Timers;
using StateChanger;
using System.Windows.Forms;
using System.Drawing;
using NUnit.Framework;

namespace StateChanger
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
		private const int movingFactor = 2;
		private readonly int skinDimension = 50;
		private readonly int screenSizeWidth = 1080;
		private readonly int screenSizeHeight = 980;

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
            Position.X = Position.X - skinDimension;
			Position.Y = Position.Y;
		}

		/// <summary>
		/// The method gives the BlackStain malus a new Position that leaves the Y
		/// position unchanged, while the X position decreases so that the object moves
		/// from right to left
		/// </summary>
		private void UpdatePositionX()
		{
			Position.X = Position.X - 3 * movingFactor;
			Position.Y = Position.Y;
		}

		/// <inheritdoc />
		public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
		{
			ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

			UpdatePositionX();

			if (collided)
			{
				ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, 0, 0, screenSizeWidth, screenSizeHeight);
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

		[TestFixture]
		class TestBlackStain
		{
			private const int screenSizeWidth = 1080;
			private const int screenSizeHeight = 980;
			private Image? imagePlaceHolder;

			private Position position;
			private Position halfwayPosition;
			private Skin skin;

			[SetUp]
			public void SetUp()
			{
				imagePlaceHolder = null;

				position = new Position(screenSizeWidth, screenSizeHeight / 2);
				halfwayPosition = new Position(screenSizeWidth / 2, screenSizeHeight / 2);
				skin = new Skin("blackstain", imagePlaceHolder, position.X, position.Y);
			}

			[Test]
			public void BlackStainMalusMovement()
			{
				BlackStain blackStain1 = new(this.position, this.skin);
				blackStain1.UpdatePositionX();
				Assert.True(blackStain1.Position.X == position.X - 3 * movingFactor);
				Assert.True(blackStain1.Position.Y == position.Y);

				BlackStain blackStain2 = new(this.halfwayPosition, this.skin);
				blackStain2.UpdatePositionX();
				Assert.True(blackStain2.Position.X == halfwayPosition.X - 3 * movingFactor);
				Assert.True(blackStain2.Position.Y == halfwayPosition.Y);

			}
		}

	}
}
