using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TestProject1
{    
    public class Tests
    {
        static void Main(string[] args)
        {
            var test = new Tests();
            test.Setup();
        }

        [SetUp]
        public void Setup()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(x => x.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false))
                .Build();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
