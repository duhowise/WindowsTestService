using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsTestService
{
	public static	class ConfigureService
	{
		internal static void Configure()
		{
			HostFactory.Run(configure =>
			{
				configure.Service<UserHostService>(service =>
				{
					service.ConstructUsing(s => new UserHostService());
					service.WhenStarted(s=>s.Start());
					service.WhenStopped(s=>s.Stop());
				});
				//System Account Setup

				configure.RunAsLocalSystem();
				configure.SetServiceName("DuhpUserHost Service");
				configure.SetDisplayName("Duhp UserHost Service");
				configure.SetDescription("UserHost Service Api");
			});
		}
	}
}
