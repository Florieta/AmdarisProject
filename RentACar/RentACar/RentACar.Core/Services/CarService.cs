using Microsoft.EntityFrameworkCore;
using RentACar.Core.Contracts;
using RentACar.Core.Models.Car;
using RentACar.Infrastructure.Data.Common;
using RentACar.Infrastructure.Entitites;
using RentACar.Infrastructure.Entitites.Identity;
using RentalCarManagementSystem.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository repo)
        {
            this.repo = repo;

        }
        public async Task<IEnumerable<AllCarsViewModel>> GetAllCarsAsync()
        {
            var allcars = await repo.All<Car>().ToListAsync();

            return allcars
           .Select(m => new AllCarsViewModel()
           {
               Id = m.Id,
               Make = m.Make,
               Model = m.Model,
               RegNumber = m.RegNumber,
               ImageUrl = m.ImageUrl,
               DailyRate = m.DailyRate,
               IsAvailable = m.IsAvailable
           });
        }

        public async Task CreateCar(CreateCarInputModel model)
        {
            if (await IsCarExists(model))
            {
                throw new ArgumentException("The car has already existed!");
            }

            var car = new Car()
            {
                Id = model.Id,
                Make = model.Make,
                Model = model.Model,
                MakeYear = model.MakeYear,
                RegNumber = model.RegNumber,
                AirCondition = model.AirCondition,
                Doors = model.Doors,
                Seats = model.Seats,
                Fuel = model.Fuel,
                Transmission = model.Transmission,
                NavigationSystem = model.NavigationSystem,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                DailyRate = model.DailyRate,
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();

        }

        public async Task<CarDetailsViewModel> CarDetailsById(int id)
        {
            var car = await this.repo.AllReadonly<Car>().Where(c => c.Id == id)
            .Select(c => new CarDetailsViewModel()
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                RegNumber = c.RegNumber,
                MakeYear = c.MakeYear,
                ImageUrl = c.ImageUrl,
                DailyRate = c.DailyRate,
                IsAvailable = c.IsAvailable,
                AirCondition = c.AirCondition,
                Doors = c.Doors,
                Seats = c.Seats,
                Fuel = c.Fuel,
                Transmission = c.Transmission,
                NavigationSystem = c.NavigationSystem,
                CategoryName = c.Category.CategoryName
            }).FirstOrDefaultAsync();

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            return car;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.AllReadonly<Category>().ToListAsync();
        }

        public async Task<bool> IsCarExists(CreateCarInputModel model)
        {
            return await repo.All<Car>()
                .AnyAsync(x => x.RegNumber == model.RegNumber);
        }

        public async Task<bool> IsDealer(string userId)
        {
            return await repo.All<ApplicationUser>().AnyAsync(a => a.Id == userId && a.IsDealer == true);

        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.All<Category>()
                .AnyAsync(a => a.Id == categoryId);
        }

        public async Task<Car> GetCarById(int Id)
        {
            return await repo.GetByIdAsync<Car>(Id);
        }


    }
}

