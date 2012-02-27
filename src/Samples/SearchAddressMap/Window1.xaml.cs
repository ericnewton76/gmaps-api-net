using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;
using Google.Maps;

namespace SearchAddressMap
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

		private void refreshMap()
		{
			if (resultsTreeView.SelectedItem == null) return;

			var location = ((LatLng)((TreeViewItem)resultsTreeView.SelectedItem).Tag);
			var map = new StaticMapRequest();
			map.Center = location;
			map.Zoom = Convert.ToInt32(zoomSlider.Value);
			map.Size = new System.Drawing.Size(332, 332);
			map.Markers.Add(map.Center);
			map.MapType = (MapTypes)Enum.Parse(typeof(MapTypes), ((ComboBoxItem)mapTypeComboBox.SelectedItem).Content.ToString(),true);
			map.Sensor = false;

			var image = new BitmapImage();
			image.BeginInit();
			image.CacheOption = BitmapCacheOption.OnDemand;
			image.UriSource = map.ToUri();
			image.DownloadFailed += new EventHandler<ExceptionEventArgs>(image_DownloadFailed);
			image.EndInit();
			image1.Source = image;
		}

		void image_DownloadFailed(object sender, ExceptionEventArgs e)
		{
			MessageBox.Show(e.ErrorException.Message, "Couldn't retrieve map");
		}

		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			var request = new GeocodingRequest();
			request.Address = searchTextBox.Text;
			request.Sensor = "false";
			var response = GeocodingService.GetResponse(request);

			if (response.Status == ServiceResponseStatus.Ok)
			{
				resultsTreeView.ItemsSource = response.Results.ToTree();
			}
		}

		private void resultsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			refreshMap();
		}

		private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (zoomLabel != null)
			{
				zoomLabel.Content = zoomSlider.Value.ToString("0x");
				refreshMap();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			zoomLabel.Content = zoomSlider.Value.ToString("0x");
		}

		private void mapTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			refreshMap();
		}
	}
}
