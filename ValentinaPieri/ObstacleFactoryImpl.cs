using Utilities;
using ObstacleFactory;

namespace ObstacleFactory
{
    /// <summary>
    /// ObstacleFactoryImpl is a class that implements the interface ObstacleFactory
    /// </summary>
    public class ObstacleFactoryImpl
    {
        /// <summary>
        /// FixedObstacleFactory is a method that creates a factory using position and
        /// skin to generate a FixedObstacle
        /// </summary>
        /// <param name="position"> - the position for a FixedObstacle</param>
        /// <param name="skin">     - the skin for a FixedObstacle</param>
        /// <returns>FixedObstacle</returns>
        public FixedObstacle FixedObstacleFactory(Position position, Skin skin) => new(position, skin);

        /// <summary>
        /// MovingObstacleFactory is a method that creates a factory using position and
        /// skin to generate a MovingObstacle
        /// </summary>
        /// <param name="position"> - the position for a MovingObstacle</param>
        /// <param name="skin">     - the skin for a MovingObstacle</param>
        /// <returns>MovingObstacle</returns>
        public MovingObstacle MovingObstacleFactory(Position position, Skin skin) => new(position, skin);
    }

}