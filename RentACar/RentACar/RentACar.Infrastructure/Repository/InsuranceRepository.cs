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
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly ApplicationDbContext _context;

        public InsuranceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Insurance insurance)
        {
            await _context.Insurances.AddAsync(insurance);
        }

        public async Task<List<Insurance>> GetAll()
        {
            return await _context.Insurances
                .ToListAsync();
        }

        public async Task<Insurance> GetById(int insuranceId)
        {
            var insurance = await _context.Insurances
                .SingleOrDefaultAsync(p => p.InsuranceCode == insuranceId);

            return insurance;
        }

        public void Remove(Insurance insurance)
        {
            _context.Insurances.Remove(insurance);
        }

        public async Task Update(Insurance insurance)
        {
            _context.Update(insurance);
        }
    }
}
