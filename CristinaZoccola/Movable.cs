using System;
using System.Collections.Generic;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola 
{
    /// <summary>
    /// A class that represents all entities that will move on the map
    /// </summary>
	public abstract class Movable
	{
	    private Position _position;

        /// <param name="position">the initial spawning position of the entity</param>
        public Movable(Position position) => _position = position;

        /// <summary>
        /// Getter of the entity position
        /// </summary>
        /// <returns>the current position of the entity</returns>
	    public Position GetPosition() => _position;

        /// <summary>
        /// Setter of the entity position
        /// </summary>
        /// <param name="position">the new position of the entity</param>
	    public void SetPosition(Position position) => _position = position;

        /// <summary>
        /// A method that will be used to animate all the entities on the map
        /// </summary>
        /// <param name="paintEventArgs">the object that will draw the entities on the map</param>
	    public abstract void Animate(PaintEventArgs paintEventArgs);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Movable movable &&
                   EqualityComparer<Position>.Default.Equals(_position, movable._position);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(_position);
        }
    }
}