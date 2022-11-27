using RentalCarManagementSystem.Core.Models.Car;
using RentalCarSystem.Core.Models.Car;
using RentalCarSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Core.Contracts
{
    public interface ICarService
    {
        Task CreateCar(CreateCarInputModel model);

        Task<bool> IsCarExists(CreateCarInputModel model);

        Task<IEnumerable<CarServiceModel>> GetAllCarsAsync();

        Task<CarDetailsViewModel> CarDetailsById(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task CheckOut(int id);

        Task<bool> Exists(int id);

        Task<bool> IsAvailable(int id);
    }
}
