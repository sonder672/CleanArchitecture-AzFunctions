using Microsoft.EntityFrameworkCore;

namespace TaskMicroservice.EFCore.DataContext;

public class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}
