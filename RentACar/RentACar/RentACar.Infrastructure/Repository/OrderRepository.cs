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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<Order> GetById(int orderId)
        {
            var order = await _context.Orders
                .SingleOrDefaultAsync(p => p.Id == orderId);

            return order;
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task Update(Order order)
        {
            _context.Update(order);
        }
    }
}
