using RentACar.Domain.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetById(string id);

        Task Add(ApplicationUser user);

        void Remove(ApplicationUser user);

        Task<List<ApplicationUser>> GetAll();

        Task Update(ApplicationUser user);
    }
}
