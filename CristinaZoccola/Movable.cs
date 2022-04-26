using System;

namespace OOP21_floppy_floppa_c_sharp.CristinaZoccola 
{
	public abstract class Movable
	{
	    private Position _position;

        public Movable(Position position) => _position = position;

	    public Position GetPosition() => _position;

	    public void SetPosition(Position position) => _position = position;

	    public abstract void Animate(PaintEventArgs paintEventArgs);

        public override bool Equals(object obj)
        {
            Movable other = (Movable)obj;

            if(other == null)
            {
                return false;
            }

            return _position.Equals(other.GetPosition);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}