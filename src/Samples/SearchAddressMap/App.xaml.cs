using System.Windows;

namespace SearchAddressMap
{
	/// <summary>
	/// Sample application to demonstrate how to use the service library
	/// provided by Google Maps API for .NET
	/// </summary>
	public partial class App : Application
	{
		private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
			MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = true;
		}
	}
}
