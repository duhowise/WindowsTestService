using System;

namespace WindowsTestService.Services
{
	public class UserHostService
	{
		public void Start()
		{
			Console.WriteLine("Duhp UserHost Service Started");
		}

		public void Stop()
		{
		    Console.WriteLine("Stopping service");
		}


	}
}