using Utilities;
using System.Timers;
using StateChanger;
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
			Position = new(Position.X - 3 * movingFactor, Position.Y);
		}

		/// <inheritdoc />
		public override void Animate(Graphics canvas)
		{
			canvas.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

			UpdatePositionX();

			if (collided)
			{
				canvas.DrawImage(Skin.Image, 0, 0, screenSizeWidth, screenSizeHeight);
			}
		}

		/// <summary>
		/// OnTimedEvent stops the timer
		/// <summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnTimedEvent(object? sender, ElapsedEventArgs? e)
		{
			this.collided = false;
			this.timer.Stop();
		}

		/// <summary>
		/// TestBlackStain is a class that tests the UpdatePositionX of BlackStain
		/// </summary>
		[TestFixture]
		class TestBlackStain
		{
			private const int screenSizeWidth = 1080;
			private const int screenSizeHeight = 980;

			private const Image imagePlaceHolder = null;
			private static readonly Position position = new(screenSizeWidth, screenSizeHeight / 2);
			private static readonly Position halfwayPosition = new(screenSizeWidth / 2, screenSizeHeight / 2);
			private readonly Skin skin = new("blackstains", imagePlaceHolder, position.X, position.Y);

			/// <summary>
			/// Check if the moving pattern of the malus works correctly
			/// </summary>
			[Test]
			public void BlackStainMalusMovement()
			{
				BlackStain blackStain1 = new(position, this.skin);
				blackStain1.UpdatePositionX();
				Assert.True(blackStain1.Position.X == position.X - 3 * movingFactor);
				Assert.True(blackStain1.Position.Y == position.Y);

				BlackStain blackStain2 = new(halfwayPosition, this.skin);
				blackStain2.UpdatePositionX();
				Assert.True(blackStain2.Position.X == halfwayPosition.X - 3 * movingFactor);
				Assert.True(blackStain2.Position.Y == halfwayPosition.Y);

			}
		}

	}
}
