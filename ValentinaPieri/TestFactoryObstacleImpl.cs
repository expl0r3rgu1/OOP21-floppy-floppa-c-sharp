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
        private const Image imagePlaceHolder = null;

        private static readonly Position position = new(screenSizeWidth, screenSizeHeight);
        private readonly Skin skinFixedObstacle = new("Pipe", imagePlaceHolder, position.X, position.Y);
        private readonly Skin skinMovingObstacle = new("Bingus", imagePlaceHolder, position.X, position.Y);

        
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
            ObstacleFactoryImpl factory = new();
            MovingObstacle movingO = new(position, skinMovingObstacle);

            Assert.True(movingO.Equals(factory.MovingObstacleFactory(position, skinMovingObstacle)));
        }

    }
}
