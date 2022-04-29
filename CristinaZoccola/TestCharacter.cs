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
        private Character characterCollideUpperPipe;
        private Character characterCollideLowerPipe;
        private Character characterCollideMovingEntity;
        private Character characterCollideUpperBorder;
        private Character characterCollideLowerBorder;
        private List<Character> characterList;
        private List<FixedObstacle> fixedObstacleList;
        private FixedObstacle fixedObstacle;
        private List<MovingObstacle> movingObstacleList;
        private MovingObstacle movingObstacle;
        private Image imagePlaceHolder;
        private Skin skin;
        private Position fixedObstaclePosition;
        private Position movingObstaclePosition;
        private Position characterCollideUpperPipePosition;
        private Position characterCollideLowerPipePosition;
        private Position characterCollideMovingEntityPosition;
        private Position characterCollideUpperBorderPosition;
        private Position characterCollideLowerBorderPosition;

        [SetUp]
        public void SetUp()
        {
            imagePlaceHolder = null;
            skin = new Skin("skin", imagePlaceHolder, skinWidth, skinHeight);

            fixedObstaclePosition = new Position(screenWidth / 2, screenHeight / 2);
            fixedObstacle = new ObstacleFactoryImpl().FixedObstacleFactory(fixedObstaclePosition, skin);
            fixedObstacleList = new List<FixedObstacle>()
            {
                fixedObstacle
            };

            movingObstaclePosition = new Position(screenWidth / 2, screenHeight / 2);
            movingObstacle = new ObstacleFactoryImpl().MovingObstacleFactory(movingObstaclePosition, skin);
            movingObstacleList = new List<MovingObstacle>()
            {
                movingObstacle
            };

            characterCollideUpperPipePosition = new Position(screenWidth / 2, screenHeight / 5);
            characterCollideUpperPipe = new Character(characterCollideUpperPipePosition, skin);

            characterCollideLowerPipePosition = new Position(screenWidth / 2, screenHeight * 4 / 5);
            characterCollideLowerPipe = new Character(characterCollideLowerPipePosition, skin);

            characterCollideMovingEntityPosition = new Position(screenWidth + movingObstacleList[0].Skin.Width / 2, screenHeight + movingObstacleList[0].Skin.Height / 2);
            characterCollideMovingEntity = new Character(characterCollideMovingEntityPosition, skin);

            characterCollideUpperBorderPosition = new Position(skinWidth / 2, -1);
            characterCollideUpperBorder = new Character(characterCollideUpperBorderPosition, skin);

            characterCollideLowerBorderPosition = new Position(screenWidth / 2, screenHeight + 1);
            characterCollideLowerBorder = new Character(characterCollideLowerBorderPosition, skin);

            characterList = new List<Character>
            {
                characterCollideUpperPipe,
                characterCollideLowerPipe,
                characterCollideMovingEntity,
                characterCollideUpperBorder,
                characterCollideLowerBorder
            };
        }
    }
}
