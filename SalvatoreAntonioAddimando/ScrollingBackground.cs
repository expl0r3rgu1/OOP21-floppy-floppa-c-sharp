using System.Windows.Forms;
using System.Drawing;
using Utilities;

namespace InfiniteMap
{
    /// <summary>
    /// A Decorator of Background that makes of two still Backgrounds a scrollable one
    /// </summary>
    class ScrollingBackground
    {
        private readonly Background backOne;
        private readonly Background backTwo;

        /// <param name="name">The name of the ScrollingBackground</param>
        /// <param name="image">The image that will be displayed</param>
        public ScrollingBackground(string name, Image image)
        {
            backOne = new Background(name, image);
            backTwo = new Background(name, image, new Position(1920, 0));
        }

        /// <summary>
        ///  Animates the two Background instances, updates their Position and moves them to the right edge of the screen when if Background.isOffStageLeft() returns true
        /// </summary>
        /// <param name="ribbonPaintEventArgs">A RibbonElementPaintEventArgs canvas to animate the two Background instances onto</param>
        public void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs)
        {
            backOne.Animate(ribbonPaintEventArgs);
            backTwo.Animate(ribbonPaintEventArgs);

            backOne.UpdatePosition();
            backTwo.UpdatePosition();

            if (backOne.IsOffStageLeft())
            {
                backOne.MoveToRightScreenEdge();
            }

            if (backTwo.IsOffStageLeft())
            {
                backTwo.MoveToRightScreenEdge();
            }
        }
    }
}