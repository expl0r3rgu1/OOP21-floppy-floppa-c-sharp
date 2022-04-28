using Utilities;
using StateChanger;
using System.Windows.Forms;

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
            Position.X = Position.X - 3 * movingFactor;
            Position.Y = Position.Y;
        }

        /// <inheritdoc />
        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

            UpdatePositionX();
        }

    }
}
