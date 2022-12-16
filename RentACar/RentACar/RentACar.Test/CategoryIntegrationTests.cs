using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RentACar.WebApi.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Test
{
    public class CategoryIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory;
        public CategoryIntegrationTests()
        {
            _factory = new CustomWebAplicationFactory<Program>();
        }

        [Fact]
        public async Task GetById_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Category/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetById_ShouldRetunr404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Category/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task All_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Category");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task CreateCategory_ShouldReturnResponse()
        {
            var newCategory = new AddCategoryModel
            {
                CategoryName = "Luxury",

            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/Category", new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_ShouldReturnNoContent()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/Category/2");
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task DeleteCategory_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Category/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task EditCategory_ShouldReturnResponse()
        {

            var updateCategory = new EditCategoryViewModel
            {
                CategoryName = "Intermediate"
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/Category/1", new StringContent(JsonConvert.SerializeObject(updateCategory), Encoding.UTF8, "application/json"));

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
