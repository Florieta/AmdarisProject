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

        //IApplicationUserRepository userRepository, IInsuranceRepository insuranceRepository,
        //    ILocationRepository locationRepository,
        public UnitOfWork(ApplicationDbContext dataCOntext, ICarRepository carRepository,
            ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _dataContext = dataCOntext;
            CarRepository = carRepository;
            CategoryRepository = categoryRepository;
            //ApplicationUserRepository = userRepository;
            //InsuranceRepository = insuranceRepository;
            //LocationRepository = locationRepository;
            OrderRepository = orderRepository;

        }

        public ICarRepository CarRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        //public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        //public IInsuranceRepository InsuranceRepository { get; private set; }
        //public ILocationRepository LocationRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
