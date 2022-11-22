using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository _repo;

        public CarService(IRepository repo)
        {
            _repo = repo;
        }
    }
}
