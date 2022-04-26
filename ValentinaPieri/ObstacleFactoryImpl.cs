using System;
using System.Drawing;

public class ObstacleFactoryImpl
{
    public FixedObstacle fixedObstacleFactory(Position _position, Image _image) => new FixedObstacle(_position, _image);

    public MovingObstacle movingObstacleFactory(Position _position, Image _image) => new MovingObstacle(_position, _image);
}