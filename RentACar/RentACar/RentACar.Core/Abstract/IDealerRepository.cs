using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IDealerRepository
    {
        Task<Dealer> GetByIdAsync(int dealerId);

        Task AddAsync(Dealer dealer);

        Task<List<Dealer>> GetAllAsync();

        Task Update(Dealer dealer);
    }
}
