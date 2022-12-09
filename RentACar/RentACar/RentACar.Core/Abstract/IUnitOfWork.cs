using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        //public IApplicationUserRepository ApplicationUserRepository { get; }

        //public IInsuranceRepository InsuranceRepository { get; }

        //public ILocationRepository LocationRepository { get; }

        public IOrderRepository OrderRepository { get; }

        Task Save();
    }
}
