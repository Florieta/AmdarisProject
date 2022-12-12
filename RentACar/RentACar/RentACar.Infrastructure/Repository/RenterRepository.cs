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
    public class RenterRepository : IRenterRepository
    {
        private readonly ApplicationDbContext _context;

        public RenterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Renter renter)
        {
            await _context.Renters.AddAsync(renter);
        }

        public async Task<List<Renter>> GetAllAsync()
        {
            return await _context.Renters
                .ToListAsync();
        }

        public async Task<Renter> GetByIdAsync(int renterId)
        {
            var renter = await _context.Renters
                .FirstOrDefaultAsync(p => p.Id == renterId);

            return renter;
        }

        public async Task Update(Renter renter)
        {
            _context.Update(renter);
        }

    }
}
