using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Models.Car;
using RentalCarSystem.Core.Contracts;
using RentalCarSystem.Core.Models.Car;
using RentalCarSystem.Infrastructure.Data.Common;
using RentalCarSystem.Infrastructure.Entities;
using RentalCarSystem.Infrastructure.Entities.Enum.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository repo)
        {
            this.repo = repo;

        }

        public async Task CreateCar(CreateCarInputModel model)
        {

            if (await IsCarExists(model))
            {
                throw new ArgumentException("The car has already existed!");
            }

            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                MakeYear = model.MakeYear,
                RegNumber = model.RegNumber,
                Color = model.Color,
                GearBox = (GearBox)model.GearBox,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                DailyRate = model.DailyRate,
                IsAvailable = true

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
                Color = c.Color,
                Description = c.Description,
                GearBox = c.GearBox.ToString(),
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


        public async Task<IEnumerable<CarServiceModel>> GetAllCarsAsync()
        {
            var allcars = await repo.All<Car>().ToListAsync();

            return allcars
           .Select(m => new CarServiceModel()
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

        public async Task CheckOut(int id)
        {
            var car = await repo.GetByIdAsync<Car>(id);
            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            car.IsAvailable = true;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsAvailable(int id)
        {
            return (await repo.GetByIdAsync<Car>(id)).IsAvailable != false;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Car>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> IsCarExists(CreateCarInputModel model)
        {
            return await repo.All<Car>()
                .AnyAsync(x => x.RegNumber == model.RegNumber);
        }

    }
}
