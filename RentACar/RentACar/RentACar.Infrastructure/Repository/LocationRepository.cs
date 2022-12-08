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
    internal class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Location location)
        {
            await _context.Locations.AddAsync(location);
        }

        public async Task<List<Location>> GetAll()
        {
            return await _context.Locations
                .ToListAsync();
        }

        public async Task<Location> GetById(int locationId)
        {
            var location = await _context.Locations
                .SingleOrDefaultAsync(p => p.Id == locationId);

            return location;
        }

        public void Remove(Location location)
        {
            _context.Locations.Remove(location);
        }

        public async Task Update(Location location)
        {
            _context.Update(location);
        }
    }
}
