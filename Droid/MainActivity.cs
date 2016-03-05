
using Android.Bluetooth;
using Java.Util;



using Android.App;
//using Android.Runtime;
using Android.OS;
using Java.IO;
using Android.Content.PM;
using System.Threading.Tasks;
using Android.Util;
using Java.Interop;
using System;
using Android.Graphics;
using System.IO;
using Android.Content;
using Android.Provider;
using Java.Util.Concurrent;
using System.Collections.Generic;
using Android.Widget;
using Android.Views;


namespace TestBth.Droid
{
	[Activity (Label = "TestBth.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		const string Tag = "MainActivity";

		public static BluetoothSocket BthSocket = null;

		const int RequestResolveError = 1000;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
			/*
			BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
			if(adapter == null)
				System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");

			if(!adapter.IsEnabled)
				System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled."); 

			BluetoothDevice device = null;

			foreach (var bd in adapter.BondedDevices) {
				if (bd.Name.StartsWith ("QuickScan")) {
					device = bd;
					break;
				}
			}

			if (device == null)
				System.Diagnostics.Debug.WriteLine ("Named device not found.");
			else {
				BthSocket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
				if (BthSocket != null) {

					Task.Run (async() => {
						await BthSocket.ConnectAsync ();

						if(BthSocket.IsConnected){
							System.Diagnostics.Debug.WriteLine("Connected!");
							var mReader = new InputStreamReader(BthSocket.InputStream);
							var buffer = new BufferedReader(mReader);
							while (true){
								
								string barcode = await buffer.ReadLineAsync();
								if(barcode.Length > 0){
									System.Diagnostics.Debug.WriteLine("Letto: " + barcode);
									Xamarin.Forms.MessagingCenter.Send<App, string> ((App)Xamarin.Forms.Application.Current, "Barcode", barcode);
								}
							}
						
						}
						
					});
				}
			}
			*/
		}
	}
}

