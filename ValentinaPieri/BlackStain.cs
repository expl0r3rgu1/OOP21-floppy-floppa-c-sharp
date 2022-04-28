using floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.test;
using System.Timers;
using System.Windows.Forms;

namespace floppy_floppa_c_sharp.OOP21_floppy_floppa_c_sharp.ValentinaPieri
{
	public class BlackStain : Malus
	{
		private bool collided = false;
		private readonly Timer timer;
		private const int MovingFactor = 2;
		private readonly int skin_dimension = 50;
		private readonly int space_between_pipes = 300;
		private readonly int screen_size_width = 1080;
		private readonly int screen_size_height = 980;

        public BlackStain(Position position, Skin skin) : base(position, skin)
        {
			timer = new Timer(300);
			timer.Elapsed += new ElapsedEventHandler(ActionPerformed);
		}
	
		public override void ChangeState()
		{
			timer.Start();
			this.collided = true;
            Position.X = Position.X - skin_dimension;
			Position.Y = Position.Y;
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

			if (collided)
			{
				ribbonPaintEventArgs.Graphics.DrawImage(Skin.Image, 0, 0, screen_size_width, screen_size_height);
			}
		}

		public void ActionPerformed(object sender, ElapsedEventArgs e)
		{
			this.collided = false;
			this.timer.Stop();
		}

	}
}
