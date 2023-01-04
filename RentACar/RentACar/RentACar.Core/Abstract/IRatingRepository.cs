using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(int ratingId);

        Task<List<Rating>> GetAllAsyncByCarId(int carId);

        Task AddAsync(Rating rating);

        Task<List<Rating>> GetAllAsync();

        Task Update(Rating rating);
    }
}
