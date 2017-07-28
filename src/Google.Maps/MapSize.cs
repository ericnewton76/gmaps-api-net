namespace Google.Maps
{
	public struct MapSize
	{
		public MapSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public int Width { get; set; }

		public int Height { get; set; }

#if HAS_SYSTEMDRAWING
		public static implicit operator MapSize(System.Drawing.Size systemSize)
		{
			return new MapSize(systemSize.Width, systemSize.Height);
		}
#endif

	}
}