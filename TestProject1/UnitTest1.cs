using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using Domain.Factory;
using Domain.Command;
using Delivery.Extensions;
using Application.Interface.Menu;

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
            await test.TestMenuLogic();
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
        public async Task TestMenuLogic()
        {
            var testmenu = MenuFactory.CreateMenu(menuitem =>
            {
                menuitem
                .AddMenuItem("TestMenuItem1", "Test description1", command: () => Console.WriteLine("MenuItem1 click"))
                .AddMenuItem("TestMenuItem2", "Test description2", command: () => Console.WriteLine("MenuItem2 click"))
                .AddMenuItem("TestMenuItem3", "Test description3", command: () => Console.WriteLine("MenuItem3 click"));
            });

            await testmenu.Select("1");
            await testmenu.Select("2");
            await testmenu.Select("3");

            var menu = MenuFactory
                .CreateMenuItemBuilder()
                .AddMenuItem("TestMenuItem1", "Test description1", command: CommandCreater.Create(() => Console.WriteLine("MenuItem1 click")))
                .AddMenuItem("TestMenuItem2", "Test description2", command: CommandCreater.Create(() => Console.WriteLine("MenuItem2 click")))
                .AddMenuItem("TestMenuItem3", "Test description3", command: CommandCreater.Create(() => Console.WriteLine("MenuItem3 click")))
                .Build();

            await menu.Select("1");
            await menu.Select("2");
            await menu.Select("3");
            //var menuRepository = _databaseFactory.CreateMenuRepository();
            //var queryMenus = await menuRepository.QueryMenuItem();
            //var menuConfig = new MenuConfigure(menuRepository);

            //foreach (var item in queryMenus)
            //{
            //    menuConfig.Title = item;
            //    menuConfig.Enabled = default;
            //}

            //var build = MenuConfigure.Build();
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
            //var menus = await app.GetCommandMenu();
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
