# TestBth
Xamarin Test to connect a Bluetooth Scanner to a Xamarin Forms App

This little demo wants to connect an Android device to a Bluetooth Barcode Scanner, and send data to a Xamarin Forms Application.
In Bth.cs (Under Android Project )file there are two methods:

	void Start(string name, int sleepTime, bool readAsCharArray);
	void Cancel();
	ObservableCollection<string> PairedDevices();

Start connect to a bluetooth device, passing the "name" of bluetooth device present in bluetooth's paired devices list. "sleepTime" is a value that permits
to add a sleep time during reading (200 / 250 is a good value). "readAsCharArray" is the method library use to read data (true should be the
value)

Cancel close the communication between bluetooth device and Android device

PairedDevices return a list of paired devices present on Android device

When app start, read all Paired devices and present them in a picker. Then with Connect and Disconnect buttons you can connect to
a bluetooth device and start to read barcodes. Barcodes will be added to the list


