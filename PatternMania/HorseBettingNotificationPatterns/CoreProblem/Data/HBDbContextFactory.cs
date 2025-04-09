using HorseBettingNotifications.Core.Data;
using Microsoft.EntityFrameworkCore;

public class HBDbContextFactory : IDbContextFactory<HBDbContext>
{
    private readonly DbContextOptions<HBDbContext> _options;

    public HBDbContextFactory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<HBDbContext>();
        optionsBuilder.UseSqlite("DataSource=:memory:");
        _options = optionsBuilder.Options;
    }

    public HBDbContext CreateDbContext()
    {
        var context = new HBDbContext(_options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        return context;
    }
}
