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
        private readonly Skin skinFixedObstacle = new Skin("Blackstain.png", image, skinDimension, skinDimension);
        readonly private Skin skinMovingObstacle = new Skin("Bingus", image, skinDimension, skinDimension);

        
        [Test]
        public void TestFactoryFixedObstcle()
        {
            ObstacleFactoryImpl factory = new();
            FixedObstacle fixedO = new(position, skinFixedObstacle);

            Assert.True(fixedO.Equals(factory.FixedObstacleFactory(position, skinFixedObstacle)));
        }

        [Test]
        public void TestFactoryMovingObstcle()
        {
            ObstacleFactoryImpl factory = new ObstacleFactoryImpl();
            MovingObstacle movingO = new MovingObstacle(position, skinMovingObstacle);

            Assert.True(movingO.Equals(factory.MovingObstacleFactory(position, skinMovingObstacle)));
        }

    }
}
