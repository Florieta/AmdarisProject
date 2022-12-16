using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RentACar.Domain.Entitites.Enum.Order;
using RentACar.WebApi.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Test
{
    public class OrderIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory;
        public OrderIntegrationTests()
        {
            _factory = new CustomWebAplicationFactory<Program>();
        }

        [Fact]
        public async Task GetById_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Order/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetById_ShouldRetunr404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Order/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task All_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Order");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task CreateOrder_ShouldReturnResponse()
        {
            var newCar = new AddOrderModel
            {
                PickUpDateAndTime = new DateTime(2022, 11, 17, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 11, 23, 6, 0, 0),
                Duration = 6,
                PaymentType = PaymentType.Card,
                CarId = 3,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
                TotalAmount = 292,
                IsPaid = false,
                RenterId = 1
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/Order", new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8,
                "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task DeleteOrder_ShouldReturnNoContent()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/Order/2");
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task DeleteOrder_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Order/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task EditOrder_ShouldReturnResponse()
        {

            var updatеOrder = new EditOrderViewModel
            {
                Id = 1,
                PickUpDateAndTime = new DateTime(2022, 11, 17, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 11, 23, 6, 0, 0),
                Duration = 6,
                PaymentType = PaymentType.BankTransfer,
                CarId = 3,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
                TotalAmount = 292,
                IsPaid = true,
                Insurance = null,
                RenterId = 1
                
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/Order/1", new StringContent(JsonConvert.SerializeObject(updatеOrder), Encoding.UTF8,
                "application/json"));

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        }

        //[Fact]
        //public async Task EditCar_ShouldReturn404IfIdNotFound()
        //{

        //    var updateCar = new EditCarViewModel
        //    {
        //        Id = 101,
        //        Make = "Toyota",
        //        Model = "Corolla",
        //        MakeYear = 2022,
        //        DailyRate = 30,
        //        ImageUrl = "img.jpg",
        //        RegNumber = "B1234AB",
        //        AirCondition = true,
        //        Seats = 5,
        //        Doors = 5,
        //        NavigationSystem = false,
        //        Fuel = Fuel.Hybrid,
        //        Transmission = Transmission.Automatic,
        //        DealerId = 1
        //    };
        //    var client = _factory.CreateClient();
        //    var response = await client.PutAsync("api/Car/101", new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json"));

        //    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        //}


        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
