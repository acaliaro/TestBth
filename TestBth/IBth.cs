using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestBth
{
	public interface IBth
	{
		void Start(string name, int sleepTime, bool readAsCharArray);
		void Cancel();
		ObservableCollection<string> PairedDevices();
	}
}

