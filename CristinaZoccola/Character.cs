using System.Windows.Forms;
using System.Timers;
using System;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola
{
    class Character : Movable
    {
        public static bool immortal = false;
        private readonly Skin _skin;
        private bool _dead;
        private bool _jumping;
        private readonly Timer _timer;

        public Character(Position position, Skin skin) : base(position)
        {
            _skin = skin;
            _dead = false;
            _jumping = false;
            _timer = new Timer(500);
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            throw new System.NotImplementedException();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _jumping = false;
            _timer.Stop();
        }

    }
}
