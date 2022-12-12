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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Where(c => c.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == categoryId);

            return category;
        }

        public void Remove(Category category)
        {
            if (!category.IsDeleted)
            {
                category.IsDeleted = true;
            }
        }

        public async Task Update(Category category)
        {
            _context.Update(category);
        }
    }
}
