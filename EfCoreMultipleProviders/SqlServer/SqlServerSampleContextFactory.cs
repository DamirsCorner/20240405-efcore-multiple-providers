using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreMultipleProviders.SqlServer;

public class SqlServerSampleContextFactory : IDesignTimeDbContextFactory<SqlServerSampleContext>
{
    public SqlServerSampleContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlServerSampleContext>().UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=EfCoreMultipleProviders;Trusted_Connection=True;MultipleActiveResultSets=true"
        );

        return new SqlServerSampleContext(optionsBuilder.Options);
    }
}
