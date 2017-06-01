using System;

using Xamarin.Forms;

namespace TestBth
{
	public class MyPage : ContentPage
	{
		public MyPage()
		{

			this.BindingContext = new MyPageViewModel();

			Picker pickerBluetoothDevices = new Picker() { Title = "Select a bth device" };
			pickerBluetoothDevices.SetBinding(Picker.ItemsSourceProperty, "ListOfDevices");
			pickerBluetoothDevices.SetBinding(Picker.SelectedItemProperty, "SelectedBthDevice");
			pickerBluetoothDevices.SetBinding(VisualElement.IsEnabledProperty, "IsPickerEnabled");

			Entry entrySleepTime = new Entry() {Keyboard = Keyboard.Numeric, Placeholder = "Sleep time" };
			entrySleepTime.SetBinding(Entry.TextProperty, "SleepTime");

			Button buttonConnect = new Button() { Text = "Connect" };
			buttonConnect.SetBinding(Button.CommandProperty, "ConnectCommand");
			buttonConnect.SetBinding(VisualElement.IsEnabledProperty, "IsConnectEnabled");

			Button buttonDisconnect = new Button() { Text = "Disconnect" };
			buttonDisconnect.SetBinding(Button.CommandProperty, "DisconnectCommand");
			buttonDisconnect.SetBinding(VisualElement.IsEnabledProperty, "IsDisconnectEnabled");

			StackLayout slButtons = new StackLayout() {Orientation = StackOrientation.Horizontal, Children = {buttonDisconnect, buttonConnect } };

			ListView lv = new ListView();
			lv.SetBinding(ListView.ItemsSourceProperty, "ListOfBarcodes");
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, ".");


			StackLayout sl = new StackLayout { Children = { pickerBluetoothDevices, entrySleepTime, slButtons, lv } };
			Content = sl;
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}

