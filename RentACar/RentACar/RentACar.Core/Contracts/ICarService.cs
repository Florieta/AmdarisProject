using RentACar.Core.Models.Car;
using RentACar.Infrastructure.Entitites;
using RentalCarManagementSystem.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Contracts
{
    public interface ICarService
    {
        Task<bool> IsCarExists(CreateCarInputModel model);

        Task CreateCar(CreateCarInputModel model);

        Task<bool> CategoryExists(int categoryId);

        Task<bool> IsDealer(string userId);

        Task<Car> GetCarById(int Id);

        Task<IEnumerable<AllCarsViewModel>> GetAllCarsAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<CarDetailsViewModel> CarDetailsById(int id);
    }
}
