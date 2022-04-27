using System;
using System.Drawing;
using ObstacleFactory;

namespace ObstacleFactory
{
    public class ObstacleFactoryImpl
    {
        public FixedObstacle FixedObstacleFactory(Position position, Skin skin) => new FixedObstacle(position, skin);

        public MovingObstacle MovingObstacleFactory(Position position, Skin skin) => new MovingObstacle(position, skin);
    }

}