using RentACar.Infrastructure.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Contracts
{
    public interface IDealerService
    {
        Task<bool> ExistsById(string userId);

        Task<ApplicationUser> GetDealer(string userId);

        Task BecomeDealer(string userId);
    }
}
