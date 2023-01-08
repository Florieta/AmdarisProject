using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACar.Application.Abstract
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int carId);

        Task AddAsync(Car car);

        void Remove(Car car);

        Task<List<Car>> GetAllAsync();

        Task Update(Car car);

        Task<List<Car>> GetCarsByDealerIdAsync(int dealerId);

    }
}
