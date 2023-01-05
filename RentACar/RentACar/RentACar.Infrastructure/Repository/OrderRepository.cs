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

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Where(b => b.IsActive == true && b.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersByRenterIdAsync(int renterId)
        {
            return await _context.Orders.Include(x => x.Car).Include(x => x.DropOffLocation).Include(x => x.PickUpLocation)
                .Where(b => b.IsActive == true && b.IsDeleted == false && b.RenterId == renterId)
                .ToListAsync();
        }
        public async Task<Order> GetByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Where(p => p.Id == orderId)
                .Include(x => x.Car)
                .Include(x => x.DropOffLocation)
                .Include(x => x.PickUpLocation)
                .Include(x => x.Renter)
                .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefaultAsync();

            return order;
        }

        public void Remove(Order order)
        {
            if (!order.IsDeleted)
            {
                order.IsDeleted = true;
            }
        }

        public async Task Update(Order order)
        {
            _context.Update(order);
        }
    }
}
