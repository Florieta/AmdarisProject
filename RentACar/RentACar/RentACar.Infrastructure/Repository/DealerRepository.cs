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
    public class DealerRepository : IDealerRepository
    {
        private readonly ApplicationDbContext _context;

        public DealerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Dealer dealer)
        {
            await _context.Dealers.AddAsync(dealer);
        }

        public async Task<List<Dealer>> GetAllAsync()
        {
            return await _context.Dealers
                .ToListAsync();
        }

        public async Task<Dealer> GetByIdAsync(int dealerId)
        {
            var dealer = await _context.Dealers
                .FirstOrDefaultAsync(p => p.Id == dealerId);

            return dealer;
        }

        public async Task Update(Dealer category)
        {
            _context.Update(category);
        }
    }
}
