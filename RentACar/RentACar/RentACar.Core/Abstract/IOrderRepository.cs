using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);

        Task<List<Order>> GetAllOrdersByRenterIdAsync(int renterId);

        Task AddAsync(Order order);

        void Remove(Order order);

        Task<List<Order>> GetAllAsync();

        Task Update(Order order);
    }
}
