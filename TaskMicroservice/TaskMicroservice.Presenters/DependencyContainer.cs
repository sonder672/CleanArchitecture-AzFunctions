using Microsoft.Extensions.DependencyInjection;
using TaskMicroservice.Services.Ports.OUT;

namespace TaskMicroservice.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IGenericTaskHandlerOutputPort, GenericPresenter>();

        return services;
    }
}
