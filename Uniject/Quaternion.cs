using System;

namespace Uniject
{
	public struct Quaternion
	{
		public float W;
		public float X;
		public float Y;
		public float Z;

		public Quaternion(float x, float y, float z, float w)
		{
			this.W = w;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
	}
}

