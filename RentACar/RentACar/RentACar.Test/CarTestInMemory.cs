using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RentACar.Core.Services;
using System.Threading.Tasks;
using RentACar.Core.Contracts;
using RentACar.Infrastructure.Data.Common;
using RentACar.Test;
using RentalCarSystem.Test;

namespace RentACar.Test
{
    [TestFixture]
    public class CarTestInMemory
    {

        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<ICarService, CarService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

        }

 
        [Test]
        public void Test1()
        {

            Assert.Pass();
        }
    }
}