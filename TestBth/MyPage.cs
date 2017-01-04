using System;

using Xamarin.Forms;
using FreshEssentials;

namespace TestBth
{
	public class MyPage : ContentPage
	{
		public MyPage()
		{

			this.BindingContext = new MyPageViewModel();

			BindablePicker pickerBluetoothDevices = new BindablePicker() { Title = "Select a bth device" };
			pickerBluetoothDevices.SetBinding(BindablePicker.ItemsSourceProperty, "ListOfDevices");
			pickerBluetoothDevices.SetBinding(BindablePicker.SelectedItemProperty, "SelectedBthDevice");
			pickerBluetoothDevices.SetBinding(VisualElement.IsEnabledProperty, "IsPickerEnabled");

			Button buttonConnect = new Button() { Text = "Connect" };
			buttonConnect.SetBinding(Button.CommandProperty, "ConnectCommand");
			buttonConnect.SetBinding(VisualElement.IsEnabledProperty, "IsConnectEnabled");

			Button buttonDisconnect = new Button() { Text = "Disconnect" };
			buttonDisconnect.SetBinding(Button.CommandProperty, "DisconnectCommand");
			buttonDisconnect.SetBinding(VisualElement.IsEnabledProperty, "IsDisconnectEnabled");

			ListView lv = new ListView();
			lv.SetBinding(ListView.ItemsSourceProperty, "ListOfBarcodes");
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, ".");


			StackLayout sl = new StackLayout { Children = { pickerBluetoothDevices, buttonConnect, buttonDisconnect, lv } };
			Content = sl;
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}

