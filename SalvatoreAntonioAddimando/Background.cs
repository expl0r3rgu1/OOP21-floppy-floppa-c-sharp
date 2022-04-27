using System.Windows.Forms;
using System.Drawing;
using Utilities.Movable;

namespace InfiniteMap
{
    class Background : Movable
    {
        private readonly string name;
        private readonly Image image;
        public string Name { get => name; }
        public Image Image { get => image; }

        public Background(string name, Image image) : base(new Position(0,0))
        {
            this.name = name;
            this.image = image;
        }

        public Background(string name, Image image, Position position) : base(position)
        {
            this.name = name;
            this.image = image;
        }

        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(image, Position.X, Position.Y, 1920, 1080);
        }

        public void UpdatePosition()
        {
            Position.X = Position.X - 2;
        }

        public bool IsOffStageLeft()
        {
            return (Position.X <= -1 * 1920);
        }
    }
}