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
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _context.Locations
                .Where(l => l.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int locationId)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(p => p.Id == locationId);

            return location;
        }

        public void Remove(Location location)
        {
            if (!location.IsDeleted)
            {
                location.IsDeleted = true;
            }
        }

        public async Task Update(Location location)
        {
            _context.Update(location);
        }
    }
}
