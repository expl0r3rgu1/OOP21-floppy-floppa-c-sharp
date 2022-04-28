using Utilities;
using System.Windows.Forms;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    public class CoinsReducer : Malus
    {
        private const int MovingFactor = 2;
        private int PlayPanel_reducerTimes = 0;

        public CoinsReducer(Position position, Skin skin) : base(position, skin) { }

        public override void ChangeState()
        {
            PlayPanel_reducerTimes++;
            MoveOffScreen();
        }

        private void UpdatePositionX()
        {
            Position.X = Position.X - 3 * MovingFactor;
            Position.Y = Position.Y;
        }

        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, Position.X, Position.Y, Skin.Width, Skin.Height);

            UpdatePositionX();
        }

    }
}
