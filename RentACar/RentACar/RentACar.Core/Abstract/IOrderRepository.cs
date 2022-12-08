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
        Task<Order> GetById(int id);

        Task Add(Order order);

        void Remove(Order order);

        Task<List<Order>> GetAll();

        Task Update(Order order);
    }
}
