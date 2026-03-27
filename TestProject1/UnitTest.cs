using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using Domain.Factory;
using Delivery.Extensions;

namespace TestProject1;

public class Tests
{
    IDomainRepositoryFactory _databaseFactory;
    IServiceProvider _serviceProvider;

    [TearDown]
    public static async Task Main(string[] args)
    {
        var test = new Tests();
        test.Setup();

        //await CreateTest<TestAppConfigure>();
        //await CreateTest<TestMenu>();
        await CreateTest<TestCart>();
    }

    [SetUp]
    public void Setup()
    {
        _serviceProvider = Host
            .CreateDefaultBuilder()
            .ConfigureServices(x => x.AddApplication())
            .ConfigureHostConfiguration(x => x.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false))
            .Build().Services;

        _databaseFactory = new Infranstracture.Test.DomainRepository();
    }

    static Task CreateTest<T>() where T : IUnitTest, new()
    {
        return new T().Run();
    }
}
