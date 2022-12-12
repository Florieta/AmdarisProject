using RentACar.Application.Abstract;
using RentACar.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dataContext;


        public UnitOfWork(ApplicationDbContext dataCOntext, ICarRepository carRepository,
            ICategoryRepository categoryRepository, IOrderRepository orderRepository,
            ILocationRepository locationRepository)
        {
            _dataContext = dataCOntext;
            CarRepository = carRepository;
            CategoryRepository = categoryRepository;
            LocationRepository = locationRepository;
            OrderRepository = orderRepository;

        }

        public ICarRepository CarRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
