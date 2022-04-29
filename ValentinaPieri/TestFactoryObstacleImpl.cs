using NUnit.Framework;
using ObstacleFactory;
using System.Drawing;
using Utilities;

namespace Test
{
    [TestFixture]
    public class TestFactoryObstacleImpl
    {
        static void Main() { }

        private const int screenSizeWidth = 1080;
        private const int screenSizeHeight = 980;
        private const Image image = Image.FromFile("Blackstain.png");
        private const int skinDimension = 50;

        private readonly Position position = new Position(screenSizeWidth, screenSizeHeight);
        private readonly Skin skinFixedObstacle = new Skin("Blackstain.png", image, skinDimension, skinDimension);
        //readonly private Skin skinMovingObstacle = new Skin("Bingus", image, skinDimension, skinDimension);

        
        [Test]
        public void TestFactoryFixedObstcle()
        {
            ObstacleFactoryImpl factory = new ObstacleFactoryImpl();
            FixedObstacle fixedO = new FixedObstacle(position, skinFixedObstacle);

            Assert.True(fixedO.Equals(factory.FixedObstacleFactory(position, skinFixedObstacle)));
        }

    }
}
