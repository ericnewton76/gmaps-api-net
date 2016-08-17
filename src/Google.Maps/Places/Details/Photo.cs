using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class Photo
	{
		/// <summary>
		/// A string used to identify the photo when you perform a Photo request.
		/// </summary>
		[JsonProperty("photo_reference")]
		public string PhotoReference { get; set; }

		/// <summary>
		/// The maximum height of the image.
		/// </summary>
		[JsonProperty("height")]
		public int Height { get; set; }

		/// <summary>
		/// The maximum width of the image.
		/// </summary>
		[JsonProperty("width")]
		public int Width { get; set; }

		/// <summary>
		/// Contains any required attributions. This field will always be present, but may be empty.
		/// </summary>
		[JsonProperty("html_attributions")]
		public string[] HtmlAttributions { get; set; }
	}
}