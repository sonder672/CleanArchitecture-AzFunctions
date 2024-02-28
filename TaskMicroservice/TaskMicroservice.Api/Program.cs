using Microsoft.Extensions.Hosting;
using TaskMicroservice.IoC;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddGeneralDependencies(context.Configuration);
    })
    .Build();

host.Run();
