using System;

namespace Uniject
{
	public struct Vector3
	{
		public float X;
		public float Y;
		public float Z;

		public Vector3 (float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Vector3 (float x, float y) : this(x, y, 0)
		{
		}

        public float Magnitude
        {
            get { return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
        }

        public static float Distance (Vector3 a, Vector3 b)
        {
            return (b - a).Magnitude;
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

		public static Vector3 Lerp(Vector3 start, Vector3 end, float percentage)
		{
			return new Vector3(
				start.X + percentage * (end.X - start.X),
				start.Y + percentage * (end.Y - start.Y),
				start.Z + percentage * (end.Z - start.Z)
				);
		}
	}
}

