using System;

namespace TestBth
{
	public interface IBth
	{
		void Start(string name, int sleepTime, bool readAsCharArray);
		void Cancel();
	}
}

