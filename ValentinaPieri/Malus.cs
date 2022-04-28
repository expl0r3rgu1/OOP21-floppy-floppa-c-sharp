using floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.test;
using Utilities;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
    /// <summary>
    /// A class that implements an object that hampers the character in different ways
    /// </summary>
    public abstract class Malus : Movable
    {
        private readonly Skin skin;

        /// <summary>
        /// The skin of the entity
        /// </summary>
        public Skin Skin => skin;

        /// <param name="position">the malus initial Position</param>
        /// <param name="skin">the malus Skin</param>
        protected Malus(Position position, Skin skin) : base(position) => this.skin = skin;

        /// <summary>
        /// ChangeState is the method that changes a state of the Character or of the game
        /// </summary>
        public abstract void ChangeState();

        /// <summary>
        /// MoveOffScreen is the method that spawns the Malus out of the Screen 
        /// after been used one time
        /// </summary>
        public void MoveOffScreen()
        {
            Position.X = -skin.Width;
            Position.Y = Position.Y;
        }

    }
}
