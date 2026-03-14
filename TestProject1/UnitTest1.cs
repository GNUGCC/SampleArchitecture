using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using Domain.Factory;
using Delivery.Extensions;

namespace TestProject1
{
    public class Tests
    {
        IDomainRepositoryFactory _databaseFactory;
        IServiceProvider _serviceProvider;

        [TearDown]
        public static async Task Main(string[] args)
        {
            var test = new Tests();
            test.Setup();
            await test.TestCreateMenuRepository();
            //var database = serviceProvider.GetRequiredService<IDatabase>();
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

        [Test]
        public async Task TestCreateMenuRepository()
        {
            var menuRepository = _databaseFactory.CreateMenuRepository();
        }

        [Test]
        public async Task Test1()
        {
            //var database = _databaseFactory.CreateDatabase();
            //Assert.That(database.GetType().Name, Is.Not.Null);

            //var datas = await database.QueryAllAsync<string>();
            //database.Configure(x => x.MayExceptionProcess = e => e is not NotImplementedException and Exception);

            //var app = default(IApplication);
            //app.Version();
            //var menus = await app.ShowCommandMenu();
            //var loadmenu = menus.ElementAt(0);
            //await loadmenu.AddMenuItem(["TestA", "TestB"], [true]);
            //Assert.That(loadmenu.Count, Is.EqualTo(2));

            //var testmenu = menus.ElementAt(1);

            //await testmenu.AddMenuItem((x, item) =>
            //{
            //    x.Title = $"Test {item}";
            //    x.Enabled = item % 2 > 0;

            //    return item < 10;
            //});

            //Assert.That(testmenu.Count, Is.EqualTo(10));
        }
    }
}
