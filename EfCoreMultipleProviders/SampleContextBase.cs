using Microsoft.EntityFrameworkCore;

namespace EfCoreMultipleProviders;

public abstract class SampleContextBase(DbContextOptions options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
}
