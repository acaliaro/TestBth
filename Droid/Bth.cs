using System;
using Android.Bluetooth;
using Java.Util;
using System.Threading.Tasks;
using Java.IO;
using TestBth.Droid;
using System.Threading;


[assembly: Xamarin.Forms.Dependency (typeof (Bth))]
namespace TestBth.Droid
{
	public class Bth : IBth
	{

		private BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
		private BluetoothSocket BthSocket = null;
		private CancellationTokenSource _ct { get; set; }

		const int RequestResolveError = 1000;

		public Bth ()
		{
		}

		#region IBth implementation

		/// <summary>
		/// Start the "reading" loop 
		/// </summary>
		/// <param name="name">Name of the paired bluetooth device (also a part of the name)</param>
		public void Start(string name){
			
			Task.Run (async()=>loop(name));
		}

		private async Task loop(string name){
			BluetoothDevice device = null;

			_ct = new CancellationTokenSource ();
			while (_ct.IsCancellationRequested == false) {
			
				try {
				
					adapter = BluetoothAdapter.DefaultAdapter;

					if(adapter == null)
						System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");
					else
						System.Diagnostics.Debug.WriteLine ("Adapter found!!");

					if(!adapter.IsEnabled)
						System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled."); 
					else
						System.Diagnostics.Debug.WriteLine ("Adapter enabled!");


					foreach (var bd in adapter.BondedDevices) {
						System.Diagnostics.Debug.WriteLine ("Paired devices found: " + bd.Name.ToUpper ());
						if (bd.Name.ToUpper().IndexOf (name.ToUpper ()) >= 0) {
							device = bd;
							break;
						}
					}

					if (device == null)
						System.Diagnostics.Debug.WriteLine ("Named device not found.");
					else {
						BthSocket = device.CreateRfcommSocketToServiceRecord (UUID.FromString ("00001101-0000-1000-8000-00805f9b34fb"));
					
						if (BthSocket != null) {


							//Task.Run ((Func<Task>)loop); /*) => {
							await BthSocket.ConnectAsync ();

							if(BthSocket.IsConnected){
								System.Diagnostics.Debug.WriteLine("Connected!");
								var mReader = new InputStreamReader(BthSocket.InputStream);
								var buffer = new BufferedReader(mReader);
								//buffer.re
								while (_ct.IsCancellationRequested == false){
									if(buffer.Ready ()){
//										string barcode =  buffer
										//string barcode = buffer.

										string barcode = await buffer.ReadLineAsync();
										if(barcode.Length > 0){
											System.Diagnostics.Debug.WriteLine("Letto: " + barcode);
											Xamarin.Forms.MessagingCenter.Send<App, string> ((App)Xamarin.Forms.Application.Current, "Barcode", barcode);
										}
										else
											System.Diagnostics.Debug.WriteLine ("No data");

									}
									else
										System.Diagnostics.Debug.WriteLine ("No data to read");

									// A little stop to the uneverending thread...
									System.Threading.Thread.Sleep (200);
									if(!BthSocket.IsConnected){
										System.Diagnostics.Debug.WriteLine ("BthSocket.IsConnected = false, Throw exception");
										throw new Exception();
									}
								}

								System.Diagnostics.Debug.WriteLine ("Exit the inner loop");

							}
						}
						else
							System.Diagnostics.Debug.WriteLine ("BthSocket = null");

					}


				}
				catch{
				}

				finally{
					if (BthSocket != null)
						BthSocket.Close ();
					device = null;
					adapter = null;
				}			
			}


			System.Diagnostics.Debug.WriteLine ("Exit the external loop");
		}

		/// <summary>
		/// Cancel the Reading loop
		/// </summary>
		/// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		public void Cancel(){
			if (_ct != null) {
				System.Diagnostics.Debug.WriteLine ("Send a cancel to task!");
				_ct.Cancel ();
			}
		}


		#endregion
	}
}

