using System.Windows.Forms;
using System.Drawing;
using Utilities.Movable;

namespace InfiniteMap
{
    /// <summary>
    ///  A still background that fills the whole screen
    /// <!summary>
    class Background : Movable
    {
        private readonly string name;
        private readonly Image image;

        /// <summary>
        /// The name of the Background
        /// </summary>
        public string Name { get => name; }
        /// <summary>
        /// The image of the Background
        /// </summary>
        public Image Image { get => image; }

        /// <param name="name">The name of the Background</param>
        /// <param name="image">The image that will be displayed</param>
        public Background(string name, Image image) : base(new Position(0, 0))
        {
            this.name = name;
            this.image = image;
        }

        /// <param name="name">The name of the Background</param>
        /// <param name="image">The image that will be displayed</param>
        /// <param name="position">The starting position the image will be displayed at</param>
        public Background(string name, Image image, Position position) : base(position)
        {
            this.name = name;
            this.image = image;
        }

        /// <inheritdoc/>
        public override void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            ribbonPaintEventArgs.Graphics.DrawImage(image, Position.X, Position.Y, 1920, 1080);
        }

        /// <summary>
        ///  Moves the Background to the left by 2 pixels
        /// </summary>
        public void UpdatePosition()
        {
            Position.X = Position.X - 2;
        }

        
        /// <returns>True if the image is completely off-screen left</returns>
        public bool IsOffStageLeft()
        {
            return (Position.X <= -1 * 1920);
        }

        /// <summary>
        /// Moves the Background to the right screen edge
        /// </summary>
        public void MoveToRightScreenEdge()
        {
            Position.X = Position.X + 1920 * 2;
        }

        /// <inheritdoc/>
        public bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Background other = obj as Background;
            return base.Equals(other) && name.Equals(other.Name) && image.Equals(other.Image);
        }

        /// <inheritdoc/>
        public int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}