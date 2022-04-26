﻿using System;

public class Position
{
	private int _x;
	private int _y;

	public Position(int x, int y)
	{
		_x = x;
		_y = y;
	}

	public int GetX() => _x;

	public void SetX(int x) => _x = x;

	public int GetY() => _y;

	public void SetY(int y) => _y = y;

    public override bool Equals(object obj)
    {
		Position other = (Position)obj;

		if(other == null)
        {
			return false;
        }

        return _x == other.GetX && _y == other.GetY;

    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
