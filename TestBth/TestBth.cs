using System;

using Xamarin.Forms;

namespace TestBth
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new MyPage();
		}

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
			MessagingCenter.Send<App>(this, "Sleep"); // When app sleep, send a message so I can "Cancel" the connection
		}

		protected override void OnResume ()
		{
			MessagingCenter.Send<App>(this, "Resume"); // When app resume, send a message so I can "Resume" the connection
		}
	}
}

