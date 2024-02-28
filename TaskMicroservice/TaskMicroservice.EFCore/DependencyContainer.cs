using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMicroservice.Domain.Repositories;
using TaskMicroservice.EFCore.Repositories;

namespace TaskMicroservice.EFCore;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        // services.AddDbContext<Context>(options =>
        //     options.UseMySql(
        //         configuration["ConnectionDatabase"],
        //         serverVersion)
        //         .UseSnakeCaseNamingConvention()
        //         .LogTo(Console.WriteLine, LogLevel.Information)
        //         .EnableSensitiveDataLogging()
        //         .EnableDetailedErrors(),
        //     ServiceLifetime.Transient
        // );

        services.AddScoped<ITaskRepository, TaskRepository>();

        // services.AddScoped<IBankInterestRepository, BankInterestRepository>();
        // services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
        // services.AddScoped<IPaymentRepository, PaymentRepository>();
        // services.AddScoped<IWayToPayRepository, WayToPayRepository>();

        return services;
    }
}
