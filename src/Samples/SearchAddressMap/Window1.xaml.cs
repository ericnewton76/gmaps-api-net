using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;
using Google.Maps;
using Google.Maps.StreetView;
using System.Net.Http;
using System.IO;

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

		private void refreshImage()
		{
			if(resultsTreeView.SelectedItem == null) return;

			var location = ((LatLng)((TreeViewItem)resultsTreeView.SelectedItem).Tag);

			if(tabControl1.SelectedIndex == 0)
			{
				refreshMap(location, image1);
			}
			else if(tabControl1.SelectedIndex == 1)
			{
				refreshStreetView(location, image2);
			}
		}

		private void refreshMap(Location location, Image imageControl)
		{
			var request = new StaticMapRequest
			{
				Center = location
				,Zoom = Convert.ToInt32(zoomSlider.Value)
				,Size = new MapSize(Convert.ToInt32(imageControl.Width), Convert.ToInt32(imageControl.Height))
				,MapType = (MapTypes)Enum.Parse(typeof(MapTypes), ((ComboBoxItem)mapTypeComboBox.SelectedItem).Content.ToString(), true)
			};
			request.Markers.Add(request.Center);

			var mapSvc = new StaticMapService();

			var imageSource = new BitmapImage();
			imageSource.BeginInit();
			imageSource.StreamSource = mapSvc.GetStream(request);
			imageSource.CacheOption = BitmapCacheOption.OnLoad;
			imageSource.EndInit();

			imageControl.Source = imageSource;
		}

		private void refreshStreetView(Location location, Image imageControl)
		{
			var request = new StreetViewRequest
			{
				Location = location
				//,Zoom = Convert.ToInt32(zoomSlider.Value),
				, Size = new MapSize(Convert.ToInt32(imageControl.Width), Convert.ToInt32(imageControl.Height))
				//,MapType = (MapTypes)Enum.Parse(typeof(MapTypes), ((ComboBoxItem)mapTypeComboBox.SelectedItem).Content.ToString(), true)
				, Heading = Convert.ToInt16(Convert.ToInt16(headingSlider.Value) + 180)
				, Pitch = Convert.ToInt16(Convert.ToInt16(pitchSlider.Value))
			};

			var service = new StreetViewService();

			var imageSource = new BitmapImage();
			imageSource.BeginInit();
			imageSource.StreamSource = service.GetStream(request);
			imageSource.CacheOption = BitmapCacheOption.OnLoad;
			imageSource.EndInit();

			imageControl.Source = imageSource;
		}

		void image_DownloadFailed(object sender, ExceptionEventArgs e)
		{
			MessageBox.Show(e.ErrorException.Message, "Couldn't retrieve map");
		}

		private async void searchButton_Click(object sender, RoutedEventArgs e)
		{
			var request = new GeocodingRequest();
			request.Address = searchTextBox.Text;

			var response = await new GeocodingService().GetResponseAsync(request);

			if(response.Status == ServiceResponseStatus.Ok)
			{
				resultsTreeView.ItemsSource = response.Results.ToTree();
			}
		}

		private void resultsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			refreshImage();
		}

		private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if(zoomLabel != null)
			{
				zoomLabel.Content = zoomSlider.Value.ToString("0x");

				refreshImage();
			}
		}

		private void headingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			refreshImage();
		}
		private void pitchSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			refreshImage();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			zoomLabel.Content = zoomSlider.Value.ToString("0x");
		}

		private void mapTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			refreshImage();
		}

		private void pitchSlider_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			pitchSlider.Value = 0;
		}

		private void headingSlider_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			headingSlider.Value = 0;
		}

		private void txtGoogleApiKey_LostFocus(object sender, RoutedEventArgs e)
		{
			GoogleSigned.AssignAllServices(new GoogleSigned(txtGoogleApiKey.Text));
		}

		private void btnTestUrl_Click(object sender, RoutedEventArgs e)
		{
			System.Text.RegularExpressions.Regex keyRegex = new System.Text.RegularExpressions.Regex(@"key=([^&]*)");

			var testUrl = txtTestUrl.Text;

			testUrl = keyRegex.Replace(testUrl, "key=" + txtGoogleApiKey.Text);

			HttpClient httpClient = new HttpClient();
			var httpResponse = httpClient.GetAsync(testUrl).Result;

			if(httpResponse.IsSuccessStatusCode == false)
			{
				string message = "";
				try
				{
					message += string.Format("Status code returned: {0} {1}", httpResponse.StatusCode, httpResponse.ReasonPhrase);
					message += string.Format("\nBody:\n{0}", httpResponse.Content.ReadAsStringAsync().Result);
				} catch { }
				MessageBox.Show(message);
			}

			try
			{
				var imageSource = new BitmapImage();
				imageSource.BeginInit();
				imageSource.StreamSource = httpResponse.Content.ReadAsStreamAsync().Result;
				imageSource.CacheOption = BitmapCacheOption.OnLoad;
				imageSource.EndInit();

				image3.Source = imageSource;
			}
			catch
			{

			}
		}
	}
}
