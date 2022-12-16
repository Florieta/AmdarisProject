using Microsoft.EntityFrameworkCore;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using RentACar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars
                .Where(c => c.IsDeleted == false && c.IsAvailable == true)
                .ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int carId)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(p => p.Id == carId && p.IsDeleted == false);

            return car;
        }

        public void Remove(Car car)
        {
            if (!car.IsDeleted)
            {
                car.IsDeleted = true;
            }
        }

        public async Task Update(Car car)
        {
           _context.Update(car);
        }
    }
}
