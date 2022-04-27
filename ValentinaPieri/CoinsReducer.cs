using floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.test;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    public class CoinsReducer : Malus
    {
        public const int MovingFactor = 2;

        public CoinsReducer(Position position, Skin skin) : base(position, skin);

        public override void ChangeState()
        {
            MoveOffScreen();
        }

        private void UpdatePositionX()
        {
            Position.X = Position.X - 3 * MovingFactor;
            Position.Y = Position.Y;
        }

        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(skin.Image, Position.X, Position.Y, skin.Width, skin.Height);

            UpdatePositionX();
        }

    }
}
