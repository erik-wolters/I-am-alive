using IAmAlive;
using Topshelf;

string _AppDir = AppDomain.CurrentDomain.BaseDirectory;

var exitCode = HostFactory.Run(x =>
{
    x.Service<IAmAliveService>(s =>
    {
        s.ConstructUsing(iAmAliveService => new IAmAliveService());
        s.WhenStarted(iAmAliveService => iAmAliveService.Start());
        s.WhenStopped(iAmAliveService => iAmAliveService.Stop());
    });

    x.RunAsLocalSystem();

    x.StartAutomatically();

    x.SetServiceName("I-Am-Alive");
    x.SetDisplayName("I Am Alive");
    x.SetDescription("Log every seccond the PC is running");

    x.OnException(e =>
    {
        new CrashDumper(_AppDir).Dunp(e.Message);
    });
});

int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.ExitCode = exitCodeValue;