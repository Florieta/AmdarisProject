using MediatR;
using RentACar.Domain.Entitites;
using RentACar.Domain.Entitites.Enum.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Categories.Commands.Update
{
    public class UpdateCategory : IRequest<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
       
    }
}
