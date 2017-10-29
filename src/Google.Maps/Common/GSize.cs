namespace Google.Maps.Common
{
	public struct GSize
	{
		public GSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public int Width { get; set; }

		public int Height { get; set; }

#if HAS_SYSTEMDRAWING
		public static implicit operator GSize(System.Drawing.Size systemSize)
		{
			return new GSize(systemSize.Width, systemSize.Height);
		}
#endif

	}
}