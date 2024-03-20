using Microsoft.EntityFrameworkCore;

namespace EfCoreMultipleProviders.MySql;

public class MySqlSampleContext(DbContextOptions<MySqlSampleContext> options)
    : SampleContextBase(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().ToTable("Sample_People");
    }
}
