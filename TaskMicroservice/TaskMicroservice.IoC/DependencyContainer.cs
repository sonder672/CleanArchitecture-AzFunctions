using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMicroservice.EFCore;
using TaskMicroservice.Presenters;
using TaskMicroservice.Services;

namespace TaskMicroservice.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddGeneralDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddRepositories(configuration);
        services.AddUseCasesServices();
        services.AddPresenters();

        return services;
    }
}
