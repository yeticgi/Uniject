using System;

namespace Uniject
{
	public struct Rect
	{
		public float Left;
		public float Top;
		public float Width;
		public float Height;

		public Rect(float left, float top, float width, float height)
		{
			this.Left = left;
			this.Top = top;
			this.Width = width;
			this.Height = height;
		}
	}
}

