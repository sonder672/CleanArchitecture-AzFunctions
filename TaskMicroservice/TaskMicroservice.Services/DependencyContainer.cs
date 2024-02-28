using Microsoft.Extensions.DependencyInjection;
using TaskMicroservice.Services.Ports.IN;
using TaskMicroservice.Services.UseCases;

namespace TaskMicroservice.Services;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
    {
        services.AddScoped<ITaskHandlerInputPort, TaskActionUseCase>();

        return services;
    }
}
