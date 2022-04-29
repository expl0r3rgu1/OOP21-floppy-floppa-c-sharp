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
        private Character characterCollideUpperPipe;
        private Character characterCollideLowerPipe;
        private Character characterCollideMovingEntity;
        private Character characterCollideUpperBorder;
        private Character characterCollideLowerBorder;
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
    }
}
