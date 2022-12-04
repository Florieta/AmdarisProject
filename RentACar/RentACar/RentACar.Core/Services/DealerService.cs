using Microsoft.EntityFrameworkCore;
using RentACar.Core.Contracts;
using RentACar.Infrastructure.Data.Common;
using RentACar.Infrastructure.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly IRepository repo;

        public DealerService(IRepository repo)
        {
            this.repo = repo;

        }

        public async Task BecomeDealer(string userId)
        {
            var user = await GetDealer(userId);
            if(user == null)
            {
                throw new ArgumentException("User not found!");
            }
            
            user.IsDealer = true;
            await repo.SaveChangesAsync();
        }
        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<ApplicationUser>()
                .AnyAsync(a => a.Id == userId);
        }

        public async Task<ApplicationUser> GetDealer(string userId)
        {
            return await repo.All<ApplicationUser>()
                .Where(a => a.Id == userId && a.IsDealer == true).FirstOrDefaultAsync();
        }
    }
}
