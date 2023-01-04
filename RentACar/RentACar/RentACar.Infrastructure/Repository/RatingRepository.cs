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
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            return await _context.Ratings
                .ToListAsync();
        }

        public async Task<List<Rating>> GetAllAsyncByCarId(int carId)
        {
            return await _context.Ratings.Where(x => x.CarId == carId)
                .ToListAsync();
        }

        public async Task<Rating> GetByIdAsync(int ratingId)
        {
            var renter = await _context.Ratings
                .FirstOrDefaultAsync(p => p.Id == ratingId);

            return renter;
        }


        public async Task Update(Rating rating)
        {
            _context.Update(rating);
        }

        
    }
}
