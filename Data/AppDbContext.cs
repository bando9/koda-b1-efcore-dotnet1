using Microsoft.EntityFrameworkCore;

namespace KodaStore.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {
        throw new Exception();
    }
}