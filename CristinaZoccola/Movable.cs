using System;

namespace OOP21-floppy-floppa-c-sharp.CristinaZoccola 
{
	public abstract class Movable
	{
	private Position _position;

    public Movable(Position position) => _position = position;

	public Position GetPosition() => _position;

	public void SetPosition(Position position) => _position = position;

	public abstract void Animate(PaintEventArgs paintEventArgs);
	}
}