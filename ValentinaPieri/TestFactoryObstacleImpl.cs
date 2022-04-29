using NUnit.Framework;
using ObstacleFactory;
using System.Drawing;
using Utilities;

namespace Test
{
    [TestFixture]
    public class TestFactoryObstacleImpl
    {
        private const int screenSizeWidth = 1080;
        private const int screenSizeHeight = 980;
        private const Image image = null;
        private const int skinDimension = 50;

        private readonly Position position = new Position(screenSizeWidth, screenSizeHeight);
        private readonly Skin skinFixedObstacle = new Skin("pipe", image, skinDimension, skinDimension);
        readonly private Skin skinMovingObstacle = new Skin("Bingus", image, skinDimension, skinDimension);

        

    }
}
