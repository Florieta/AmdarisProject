using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int categoryId);

        Task AddAsync(Category category);

        void Remove(Category category);

        Task<List<Category>> GetAllAsync();

        Task Update(Category category);
    }
}
