using EfCoreMultipleProviders.MySql;
using EfCoreMultipleProviders.SqlServer;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace EfCoreMultipleProviders.Tests;

public class DependencyInjectionTests
{
    public enum ProviderType
    {
        SqlServer,
        MySql
    }

    [Test]
    [TestCase(ProviderType.SqlServer, typeof(SqlServerSampleContext))]
    [TestCase(ProviderType.MySql, typeof(MySqlSampleContext))]
    public void DependencyInjectionReturnsCorrectContextForProvider(
        ProviderType provider,
        Type expectedContextType
    )
    {
        var services = new ServiceCollection();
        switch (provider)
        {
            case ProviderType.SqlServer:
                services.AddDbContext<SampleContextBase, SqlServerSampleContext>(options =>
                {
                    options.UseSqlServer(
                        "Server=(localdb)\\mssqllocaldb;Database=EfCoreMultipleProviders;Trusted_Connection=True;MultipleActiveResultSets=true"
                    );
                });
                break;
            case ProviderType.MySql:
                services.AddDbContext<SampleContextBase, MySqlSampleContext>(options =>
                {
                    var serverVersion = ServerVersion.Create(8, 0, 35, ServerType.MySql);
                    options.UseMySql(
                        "Server=localhost;Database=EfCoreMultipleProviders;User=root;Password=root",
                        serverVersion
                    );
                });
                break;
        }
        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetRequiredService<SampleContextBase>();

        context.Should().BeOfType(expectedContextType);
    }
}
