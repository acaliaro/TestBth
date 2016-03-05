using System;

using Xamarin.Forms;

namespace TestBth
{
	public class App : Application
	{
		private Label _l = new Label ();
		public App ()
		{

			ContentPage cp = new ContentPage ();

			StackLayout sl = new StackLayout ();
			sl.Padding = new Thickness (10, 10, 10, 10);
			_l = new Label ();
			_l.FontSize = 20;
			sl.Children.Add (_l);
			cp.Content = sl;

			//DependencyService.Get<IBth> ().Loop ();

			MainPage = cp;
			return;

			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};


		}

		protected override void OnStart ()
		{
			DependencyService.Get<IBth> ().Loop2 ();
			// Handle when your app starts
			MessagingCenter.Subscribe<App, string> (this, "Barcode", (sender, arg) => {
				Device.BeginInvokeOnMainThread(()=>
					_l.Text = arg);

			});
		}

		protected override void OnSleep ()
		{
			DependencyService.Get<IBth> ().Cancel ();
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			DependencyService.Get<IBth> ().Loop2 ();
			// Handle when your app resumes
		}
	}
}

