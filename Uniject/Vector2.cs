using System;

namespace Uniject
{
	public struct Vector2
	{
		public float X;
		public float Y;

		public Vector2 (float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		public static bool operator ==(Vector2 v1, Vector2 v2)
		{
			return v1.X == v2.X && v1.Y == v2.Y;
		}

		public static bool operator !=(Vector2 v1, Vector2 v2)
		{
			return v1.X != v2.X || v1.Y != v2.Y;
		}

		public override bool Equals (object obj)
		{
			if (obj is Vector2) {
				return this == (Vector2)obj;
			}
			return false;
		}

		public override int GetHashCode ()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}
	}
}

