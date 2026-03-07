using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Database.Delivery;
using Infranstracture.Interface;
using Application.Interface;
using Application.Impl.Extensions;
using Domain.Factory;

namespace TestProject1
{
    public class Tests
    {
        IDomainRepositoryFactory _databaseFactory;
        IServiceProvider _serviceProvider;

        [TearDown]
        public static void Main(string[] args)
        {
            var test = new Tests();
            test.Setup();
            var serviceProvider = test._serviceProvider;
            var database = serviceProvider.GetRequiredService<IDatabase>();
        }

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Host.CreateDefaultBuilder()
                .ConfigureServices(x => x.AddTestDatabase())
                .ConfigureHostConfiguration(x => x.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false))
                .Build().Services;

            _databaseFactory = default;
        }

        [Test]
        public async Task Test1()
        {
            var database = _databaseFactory.CreateDatabase();
            Assert.That(database.GetType().Name, Is.Not.Null);

            var datas = await database.QueryAllAsync<string>();
            database.Configure(x => x.MayExceptionProcess = e => e is not NotImplementedException and Exception);

            var app = default(IApplication);
            app.Version();
            var menus = await app.ShowCommandMenu();
            var loadmenu = menus.ElementAt(0);
            await loadmenu.AddMenuItem(["TestA", "TestB"], [true]);
            Assert.That(loadmenu.Count, Is.EqualTo(2));

            var testmenu = menus.ElementAt(1);

            await testmenu.AddMenuItem((x, item) =>
            {
                x.Title = $"Test {item}";
                x.Enabled = item % 2 > 0;

                return item < 10;
            });

            Assert.That(testmenu.Count, Is.EqualTo(10));
        }
    }
}
