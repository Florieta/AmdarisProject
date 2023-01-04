using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IRenterRepository
    {
        Task<Renter> GetByIdAsync(int renterId);
        Task AddAsync(Renter renter);

        Task<List<Renter>> GetAllAsync();

        Task Update(Renter renter);
    }
}
