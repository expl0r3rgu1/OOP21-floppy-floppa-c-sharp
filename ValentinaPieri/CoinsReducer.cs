using Utilities;
using System.Windows.Forms;
using System.Drawing;
using NUnit.Framework;

namespace StateChanger
{
    /// <summary>
    /// A class that extends Malus class and implements an entity that randomly takes
    /// away coins to the main character every time they hit this malus
	/// </summary>
    public class CoinsReducer : Malus
    {
        private const int movingFactor = 2;
        private int playPanelReducerTimes = 0;

        /// <param name="position">the CoinsReducer initial Position</param>
		/// <param name="skin">the CoinsReducer Skin</param>
        public CoinsReducer(Position position, Skin skin) : base(position, skin) { }

        /// <inheritdoc />
        public override void ChangeState()
        {
            playPanelReducerTimes++;
            MoveOffScreen();
        }

        /// <summary>
		/// The method gives the CoinsReducer malus a new Position that leaves the Y
		/// position unchanged, while the X position decreases so that the object moves
		/// from right to left
		/// </summary>
        private void UpdatePositionX()
        {
            Position = new(Position.X - 3 * movingFactor, Position.Y);
        }

        /// <inheritdoc />
        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

            UpdatePositionX();
        }

        [TestFixture]
        class TestCoinsReducer
        {
            private const int screenSizeWidth = 1080;
            private const int screenSizeHeight = 980;

            private const Image imagePlaceHolder = null;
            private static readonly Position position = new(screenSizeWidth, screenSizeHeight / 2);
            private static readonly Position halfwayPosition = new(screenSizeWidth / 2, screenSizeHeight / 2);
            private readonly Skin skin = new("coinsreducer", imagePlaceHolder, position.X, position.Y);


            [Test]
            public void CoinsReducerMalusMovement()
            {
                CoinsReducer coinsReducer1 = new(position, this.skin);
                coinsReducer1.UpdatePositionX();
                Assert.True(coinsReducer1.Position.X == position.X - 3 * movingFactor);
                Assert.True(coinsReducer1.Position.Y == position.Y);

                CoinsReducer coinsReducer2 = new(halfwayPosition, this.skin);
                coinsReducer2.UpdatePositionX();
                Assert.True(coinsReducer2.Position.X == halfwayPosition.X - 3 * movingFactor);
                Assert.True(coinsReducer2.Position.Y == halfwayPosition.Y);

            }
        }

    }
}
