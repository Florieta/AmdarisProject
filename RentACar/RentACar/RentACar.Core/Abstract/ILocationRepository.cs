using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface ILocationRepository
    {
        Task<Location> GetByIdAsync(int locationId);

        Task AddAsync(Location location);

        void Remove(Location location);

        Task<List<Location>> GetAllAsync();

        Task Update(Location location);
    }
}
