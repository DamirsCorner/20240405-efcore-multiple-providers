using Microsoft.EntityFrameworkCore;

namespace EfCoreMultipleProviders.SqlServer;

public class SqlServerSampleContext(DbContextOptions<SqlServerSampleContext> options)
    : SampleContextBase(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().ToTable("People", "Sample");
    }
}
