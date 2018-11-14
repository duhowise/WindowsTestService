using Topshelf;

namespace WindowsTestService.Services
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
			    configure.EnableServiceRecovery(x => x.RestartService(1));
				//System Account Setup
                configure.RunAsLocalSystem();
				configure.SetServiceName("DuhpUserHost Service");
				configure.SetDisplayName("Duhp UserHost Service");
				configure.SetDescription("UserHost Service Api");
			});
		}
	}
}
