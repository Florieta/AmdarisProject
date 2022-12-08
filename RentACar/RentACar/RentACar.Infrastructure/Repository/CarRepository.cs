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

        public async Task<List<Car>> GetAll()
        {
            return await _context.Cars
                .Where(c => c.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Car> GetById(int carId)
        {
            var car = await _context.Cars
                .SingleOrDefaultAsync(p => p.Id == carId);

            return car;
        }

        public void Remove(Car car)
        {
            _context.Cars.Remove(car);
        }

        public async Task Update(Car car)
        {
            _context.Update(car);
        }
    }
}
