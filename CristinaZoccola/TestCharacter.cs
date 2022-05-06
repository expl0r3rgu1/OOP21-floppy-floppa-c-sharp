using NUnit.Framework;
using CharacterSpace;
using ObstacleFactory;
using System.Drawing;
using Utilities;
using System.Collections.Generic;


namespace Test
{
    [TestFixture]
    class TestCharacter
    {
        private const int screenWidth = 1920;
        private const int screenHeight = 1080;
        private const int skinWidth = 20;
        private const int skinHeight = 20;

        private const Image imagePlaceHolder = null;
        private static readonly Skin skin = new("skin", imagePlaceHolder, skinWidth, skinHeight);

        private static readonly Position fixedObstaclePosition = new(screenWidth / 2, screenHeight / 2);
        private static readonly FixedObstacle fixedObstacle = new ObstacleFactoryImpl().FixedObstacleFactory(fixedObstaclePosition, skin);
        private readonly List<FixedObstacle> fixedObstacleList = new() { fixedObstacle };

        private static readonly Position movingObstaclePosition = new(screenWidth / 2, screenHeight / 2);
        private static readonly MovingObstacle movingObstacle = new ObstacleFactoryImpl().MovingObstacleFactory(movingObstaclePosition, skin);
        private static readonly List<MovingObstacle> movingObstacleList = new() { movingObstacle };

        private static readonly Position characterCollideUpperPipePosition = new(screenWidth / 2, screenHeight / 5);
        private static readonly Character characterCollideUpperPipe = new(characterCollideUpperPipePosition, skin);

        private static readonly Position characterCollideLowerPipePosition = new(screenWidth / 2, screenHeight * 4 / 5);
        private static readonly Character characterCollideLowerPipe = new(characterCollideLowerPipePosition, skin);

        private static  readonly Position characterCollideMovingEntityPosition = new(screenWidth / 2 + movingObstacleList[0].Skin.Width / 2,
                                                                                        screenHeight / 2 + movingObstacleList[0].Skin.Height / 2);
        private static readonly Character characterCollideMovingEntity = new(characterCollideMovingEntityPosition, skin);

        private static readonly Position characterCollideUpperBorderPosition = new(skinWidth / 2, -1);
        private static readonly Character characterCollideUpperBorder = new(characterCollideUpperBorderPosition, skin);

        private static readonly Position characterCollideLowerBorderPosition = new(screenWidth / 2, screenHeight + 1);
        private static readonly Character characterCollideLowerBorder = new(characterCollideLowerBorderPosition, skin);

        private readonly List<Character> characterList = new()
        {
            characterCollideUpperPipe,
            characterCollideLowerPipe,
            characterCollideMovingEntity,
            characterCollideUpperBorder,
            characterCollideLowerBorder
        };

        /// <summary>
        /// Checks if the character collides correctly with a fixed obstacle
        /// </summary>
        /// <param name="value">the position of the character in the list</param>
        [TestCase(0)]
        [TestCase(1)]
        public void CollideFixedObstacleTest(int value)
        {
            characterList[value].CollideFixedObstacle(fixedObstacleList);
            Assert.IsTrue(characterList[value].IsDead());
        }

        /// <summary>
        /// Checks if the character collides correctly with a moving entity (moving obstacle, malus and booster), 
        /// I only test with a moving obstacle
        /// </summary>
        /// <param name="value">the position of the character in the list</param>
        [TestCase(2)]
        public void CollideMovingEntityTest(int value)
        {
            characterList[value].CollideMovingObstacle(movingObstacleList);
            Assert.IsTrue(characterList[value].IsDead());
        }

        /// <summary>
        /// Checks if the character collides correctly with the upper and lower border of the map
        /// </summary>
        /// <param name="value">the position of the character in the list</param>
        [TestCase(3)]
        [TestCase(4)]
        public void CollideBordersTest(int value)
        {
            characterList[value].CollideBorders();
            Assert.IsTrue(characterList[value].IsDead());
        }
    }
}
