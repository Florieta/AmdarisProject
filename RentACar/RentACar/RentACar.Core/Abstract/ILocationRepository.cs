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
        Task<Location> GetById(int locationId);

        Task Add(Location location);

        void Remove(Location location);

        Task<List<Location>> GetAll();

        Task Update(Location location);
    }
}
