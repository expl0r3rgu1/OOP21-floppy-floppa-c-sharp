using Utilities;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    public abstract class Malus : Movable
    {
        private readonly Skin skin;

        public Skin Skin => skin;

        protected Malus(Position position, Skin skin) : base(position) => this.skin = skin;

        public abstract void ChangeState();

        public void MoveOffScreen()
        {
            Position.X = -skin.Width;
            Position.Y = Position.Y;
        }

    }
}
