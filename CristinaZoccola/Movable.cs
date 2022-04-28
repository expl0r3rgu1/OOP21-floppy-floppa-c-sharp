using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Utilities 
{
    /// <summary>
    /// A class that represents all entities that will move on the map
    /// </summary>
	public abstract class Movable
	{
	    private Position position;

        /// <summary>
        /// The position of the entity
        /// </summary>
        public Position Position { get => position; set => position = value; }

        /// <param name="position">the initial spawning position of the entity</param>
        public Movable(Position position) => this.position = position;

        /// <summary>
        /// A method that will be used to animate all the entities on the map
        /// </summary>
        /// <param name="paintEventArgs">the object that will draw the entities on the map</param>
	    public abstract void Animate(RibbonElementPaintEventArgs ribbonPaintEventArgs);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Movable movable &&
                   EqualityComparer<Position>.Default.Equals(this.position, movable.Position);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.position);
        }
    }
}