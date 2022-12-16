using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using RentACar.Application.Cars.Queries;
using RentACar.WebApi.Controllers;
using RentACar.Domain.Entitites.Enum.Car;
using RentACar.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using RentACar.WebApi.ViewModels.Car;

namespace RentACar.Tests
{
    [TestClass]
    public class CarControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Cars_GetAllCarsQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllCars>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CarController(_mockMapper.Object, _mockMediator.Object);
            await controller.All();
            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllCars>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Car_By_Id_GetCarByIdIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new CarController(_mockMapper.Object, _mockMediator.Object);

            await controller.GetById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Car_By_Id_GetCarQueryWithCorrectCarIdIsCalled()
        {
            int carId = 0;

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
                .Returns<GetCarById, CancellationToken>(async (q, c) =>
                {
                    carId = q.Id;
                    return await Task.FromResult(
                        new Car
                        {
                            Id = q.Id,
                            RegNumber = "B1234AB",
                            Model = "Toyota",
                            Make = "Auris",
                            MakeYear = 2020,
                            AirCondition = true,
                            Seats = 5,
                            Doors = 5,
                            NavigationSystem = false,
                            Fuel = Fuel.Diesel,
                            ImageUrl = "photo",
                            Transmission = Transmission.Manual,
                            DailyRate = 40,
                            IsAvailable = true,
                            CategoryId = 1
                        });
                });

            var controller = new CarController(_mockMapper.Object, _mockMediator.Object);

            await controller.GetById(1);

            Assert.AreEqual(carId, 1);
        }
        //[TestMethod]
        //public async Task Get_Book_By_Id_ShouldReturnOkStatusCode()
        //{
        //    _mockMediator
        //        .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(
        //                new Car
        //                {
        //                    Id = 1,
        //                    RegNumber = "B1234AB",
        //                    Model = "Toyota",
        //                    Make = "Auris",
        //                    MakeYear = 2020,
        //                    AirCondition = true,
        //                    Seats = 5,
        //                    Doors = 5,
        //                    NavigationSystem = false,
        //                    Fuel = Fuel.Diesel,
        //                    ImageUrl = "photo",
        //                    Transmission = Transmission.Manual,
        //                    DailyRate = 40,
        //                    IsAvailable = true,
        //                    CategoryId = 1
        //                });

        //    var controller = new CarController(_mockMapper.Object, _mockMediator.Object);

        //    var result = await controller.GetById(1);

        //    var okResult = result.Result as OkObjectResult;

        //    Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        //}
        //[TestMethod]

        //public async Task Get_Car_By_Id_ShouldReturnFoundCar()
        //{
        //    //Arrange
        //    var car = new Car
        //    {
        //        Id = 1,
        //        RegNumber = "B1234AB",
        //        Model = "Toyota",
        //        Make = "Auris",
        //        MakeYear = 2020,
        //        AirCondition = true,
        //        Seats = 5,
        //        Doors = 5,
        //        NavigationSystem = false,
        //        Fuel = Fuel.Diesel,
        //        ImageUrl = "photo",
        //        Transmission = Transmission.Manual,
        //        DailyRate = 40,
        //        IsAvailable = true,
        //        CategoryId = 1
        //    };
        //    _mockMediator
        //        .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(car);

        //    //Act
        //    var controller = new CarController(_mockMapper.Object, _mockMediator.Object);
        //    var result = await controller.GetById(1);

        //    var okResult = result.Result as OkObjectResult;

        //    //Assert
        //    Assert.AreEqual(car, okResult.Value);
        //}
    }
}
