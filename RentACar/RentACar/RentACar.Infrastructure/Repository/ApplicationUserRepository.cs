using Microsoft.EntityFrameworkCore;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites.Identity;
using RentACar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(p => p.Id == id);

            return user;
        }

        public void Remove(ApplicationUser user)
        {
            _context.Users.Remove(user);
        }

        public async Task Update(ApplicationUser user)
        {
            _context.Update(user);
        }
    }
}
