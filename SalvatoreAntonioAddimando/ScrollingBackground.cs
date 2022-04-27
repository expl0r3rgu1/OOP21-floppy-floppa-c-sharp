using System.Windows.Forms;
using System.Drawing;

namespace InfiniteMap
{
    class ScrollingBackground
    {
        private readonly Background backOne;
        private readonly Background backTwo;

        public ScrollingBackground(string name, Image image)
        {
            backOne = new Background(name, image);
            backTwo = new Background(name, image, new Position(1920, 0));
        }
    }
}