using RentACar.Domain.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IApplicationUserReposiory
    {
        Task<ApplicationUser> GetByIdAsync(string applicationUserId);
    }
}
