using Utilities;
using System.Windows.Forms;
using NUnit.Framework;
using System.Drawing;

namespace ObstacleFactory
{
	/// <summary>
	/// A class that implements a fixed Obstacle
	/// </summary>
	public class FixedObstacle : Movable
	{
		private readonly Skin skin;
		public const int movingFactor = 2;
		private readonly int spaceBetweenPipes = 300;
		private readonly int screenSizeWidth = 1080;
		private readonly int screenSizeHeight = 980;

		/// <summary>
		/// The Skin of the entity
		/// </summary>
		public Skin Skin => skin;

		/// <param name="position">the obstacle initial Position</param>
		/// <param name="skin">the obstacle Skin</param>
		public FixedObstacle(Position position, Skin skin) : base(position)
		{
			this.skin = skin;
		}

		/// <summary>
		/// UpdatePosition is a method that as its name says updates the position, the X,
		/// of the fixedobstacle
		/// </summary>
		private void UpdatePosition()
		{
			Position = new Position(Position.X - movingFactor, Position.Y);
		}

		/// <inheritdoc />
		public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
		{
			ribbonPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y + (int)spaceBetweenPipes / 2, screenSizeWidth / 10, screenSizeHeight - (Position.Y + (int)spaceBetweenPipes / 2));

			UpdatePosition();
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			FixedObstacle other = obj as FixedObstacle;

			if (other == null)
			{
				return false;
			}

			return base.Equals(obj) && skin.Equals(other.skin);
		}

		/// <inheritdoc />
		public override int GetHashCode() => base.GetHashCode();

		[TestFixture]
		class TestFixedObstacle
		{
			private const int screenSizeWidth = 1080;
			private const int screenSizeHeight = 980;

			private Image? imagePlaceHolder;
			private Position position;
			private Position halfPosition;
			private Skin skin;

			[SetUp]
			public void SetUp()
			{
				imagePlaceHolder = null;

				position = new Position(screenSizeWidth, screenSizeHeight / 2);
				halfPosition = new Position(screenSizeWidth / 2, screenSizeHeight / 2);
				skin = new Skin("pipe", imagePlaceHolder, position.X, position.Y);
			}

			[Test]
			public void FixedObstacleMovement()
			{
				FixedObstacle fixedObstacle1 = new(this.position, this.skin);
				fixedObstacle1.UpdatePosition();
				Assert.True(fixedObstacle1.Position.X == (position.X - movingFactor));

				/*FixedObstacle fixedObstacle2 = new(this.halfPosition, this.skin);
				fixedObstacle2.UpdatePosition();
				Assert.True(fixedObstacle2.Position.X == (halfPosition.X - movingFactor));*/
			}

		}

	}

}
