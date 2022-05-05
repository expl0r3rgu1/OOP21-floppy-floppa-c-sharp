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
			ribbonPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y + spaceBetweenPipes / 2, screenSizeWidth / 10, screenSizeHeight - (Position.Y + spaceBetweenPipes / 2));

			UpdatePosition();
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			FixedObstacle other = (FixedObstacle)obj;

			if (other == null)
			{
				return false;
			}

			return base.Equals(obj) && skin.Equals(other.skin);
		}

		/// <inheritdoc />
		public override int GetHashCode() => base.GetHashCode();

		/// <summary>
		/// TestFixedObstacle is a class that tests the UpdatePosition of FixedObstacle
		/// </summary>
		[TestFixture]
		class TestFixedObstacle
		{
			private const int screenSizeWidth = 1080;
			private const int screenSizeHeight = 980;

			private const Image imagePlaceHolder = null;
			private static readonly Position position = new(screenSizeWidth, screenSizeHeight / 2);
			private static readonly Position halfwayPosition = new(screenSizeWidth / 2, screenSizeHeight / 2);
			private readonly Skin skin = new("pipe", imagePlaceHolder, position.X, position.Y);

			/// <summary>
			/// Check if the moving pattern of the fixed obstacle works correctly
			/// </summary>
			[Test]
			public void FixedObstacleMovement()
			{
				FixedObstacle fixedObstacle1 = new(position, this.skin);
				fixedObstacle1.UpdatePosition();
				Assert.True(fixedObstacle1.Position.X == (position.X - movingFactor));

				FixedObstacle fixedObstacle2 = new(halfwayPosition, this.skin);
				fixedObstacle2.UpdatePosition();
				Assert.True(fixedObstacle2.Position.X == (halfwayPosition.X - movingFactor));
			}

		}

	}

}
