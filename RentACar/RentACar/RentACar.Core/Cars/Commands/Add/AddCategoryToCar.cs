using MediatR;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Commands.Add
{
    public class AddCategoryToCar : IRequest<Car>
    {
        public int CarId { get; set; }
        public int CategoryId { get; set; }
    }
}
