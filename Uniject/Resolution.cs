namespace Uniject
{
	public struct Resolution
	{
		public int Height;
		public int RefreshRate;
		public int Width;

		public Resolution(int width, int height, int refreshRate)
		{
			this.Width = width;
			this.Height = height;
			this.RefreshRate = refreshRate;
		}
	}
}
