using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskMicroservice.EFCore.DataContext;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string parentDirectory = Path.GetDirectoryName(currentDirectory)!;
        string path = Path.Combine(parentDirectory, "CleanArchitecture.Api");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        optionsBuilder.UseMySql(
            configuration["ConnectionDatabase"]!,
            serverVersion)
        .UseSnakeCaseNamingConvention();

        return new Context(optionsBuilder.Options);
    }
}