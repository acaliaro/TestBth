# TestBth
Xamarin Test to connect a Bluetooth Scanner to a Xamarin Forms App

Ok, my english is not very good, but I hope to be clear.

This little demo wants to connect an Android device to a Bluetooth Barcode Scanner, and send data to a Xamarin Forms Application.
In Bth.cs file there are two methods:

a Start method that has to be called with DependencyService on OnStart and OnResume method in App.cs

a Cancel method that has to be called with DependencyService on OnSleep method in App.cs


