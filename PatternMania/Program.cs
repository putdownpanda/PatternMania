using HorseBettingNotifications.Core.Data;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<HBDbContext>()
    .UseSqlite("DataSource=:memory:")
    .Options;

using var context = new HBDbContext(options);
context.Database.OpenConnection(); // Required for in-memory SQLite
context.Database.EnsureCreated();

// Now context is seeded and usable
