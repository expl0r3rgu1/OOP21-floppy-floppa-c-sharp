using System;
using System.Drawing;

public class ObstacleFactoryImpl
{
	public FixedObstacle fixedObstacleFactory(Poition _position, Image _image)
    {
        return new FixedObstacle(_position, _image);
    }

    public MovingObstacle movingObstacleFactory(Poition _position, Image _image)
    {
        return new MovingObstacle(_position, _image);
    }
}
