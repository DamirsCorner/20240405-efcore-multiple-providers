using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace EfCoreMultipleProviders.MySql;

public class MySqlSampleContextFactory : IDesignTimeDbContextFactory<MySqlSampleContext>
{
    public MySqlSampleContext CreateDbContext(string[] args)
    {
        var serverVersion = ServerVersion.Create(8, 0, 35, ServerType.MySql);
        var optionsBuilder = new DbContextOptionsBuilder<MySqlSampleContext>().UseMySql(
            "Server=localhost;Database=EfCoreMultipleProviders;User=root;Password=root",
            serverVersion
        );

        return new MySqlSampleContext(optionsBuilder.Options);
    }
}
