//using Moq;
//using RentalCarSystem.Infrastructure.Data.Common;
//using RentalCarSystem.Core.Contracts;
//using RentalCarSystem.Core.Models.Car;
//using RentalCarSystem.Core.Services;
//using RentalCarSystem.Infrastructure.Entities.Enum.Car;
//using RentalCarSystem.Infrastructure.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RentalCarSystem.Test
//{
//    [TestFixture]
//    public class CarTestMock
//    {
//        /// <summary>
//        /// Mock
//        /// </summary>
//        /// 
        
//        [SetUp]

//        public async void SetUp()
//        {
//            var list = new List<Car>();
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(x => x.All<Car>()).Returns(list.AsQueryable());
//            mockRepo.Setup(x => x.AddAsync<Car>(It.IsAny<Car>())).Callback((Car car) => list.Add(car));
//            mockRepo.Setup(x => x.GetByIdAsync<Car>(It.IsAny<Car>())).Callback((Car car) => car);
//            var service = new CarService(mockRepo.Object);

//            await service.GetAllCarsAsync();
//        }

//        [Test]
//        public async Task AddCar_ShouldReturnTheListWithTheAddedCar()
//        {
//            //Arrange
//            var list = new List<Car>();
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(x => x.AddAsync<Car>(It.IsAny<Car>())).Callback((Car car) => list.Add(car));
//            var service = new CarService(mockRepo.Object);

//            // Act
//            await service.CreateCar(new CreateCarInputModel()
//            {
//                RegNumber = "B1234AB",
//                Make = "Toyota",
//                Model = "Corolla",
//                MakeYear = 2022,
//                Color = "Black",
//                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
//                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
//                GearBox = GearBox.Manual,
//                DailyRate = 40,
//                IsAvailable = true,
//                CategoryId = 3,
//            });
//            // Assert

//            Assert.NotNull(list);
//            Assert.Equals(1, list.Count);
//        }
//        [Test]
//        public async Task GetCarById_ShouldReturnASpecificCarWithThisId()
//        {
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(x => x.GetByIdAsync<Car>(It.IsAny<Car>())).Callback((Car car) => car);
//            var service = new CarService(mockRepo.Object);
//            await service.CreateCar(new CreateCarInputModel()
//            {
//                RegNumber = "B1234AB",
//                Make = "Toyota",
//                Model = "Corolla",
//                MakeYear = 2022,
//                Color = "Black",
//                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
//                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
//                GearBox = GearBox.Manual,
//                DailyRate = 40,
//                IsAvailable = true,
//                CategoryId = 3,
//            });
//            // Act
//            var car = await service.Exists(1);

//            // Assert
//            Assert.NotNull(car);
//            Assert.IsTrue(car);
//        }

       

//        [Test]
//        public async Task GetAllCars_ShouldReturnListsOfCars()
//        {
           
//            //Arrange
//            var list = new List<Car>();
//            var mockRepo = new Mock<IRepository>();
//            mockRepo.Setup(x => x.AddAsync<Car>(It.IsAny<Car>())).Callback((Car car) => list.Add(car));
//            var service = new CarService(mockRepo.Object);

//            await service.CreateCar(new CreateCarInputModel()
//            {
//                RegNumber = "B1234AB",
//                Make = "Toyota",
//                Model = "Corolla",
//                MakeYear = 2022,
//                Color = "Black",
//                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
//                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
//                GearBox = GearBox.Manual,
//                DailyRate = 40,
//                IsAvailable = true,
//                CategoryId = 3,
//            });
//            // Act
//            var cars = service.GetAllCarsAsync();

//            // Assert
//            Assert.NotNull(cars);
//            Assert.Equals(1, list.Count);
//        }

//    }

//}
