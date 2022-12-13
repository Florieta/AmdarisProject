using MediatR;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Commands.Delete
{
    public class DeleteLocation : IRequest<Location>
    {
        public int Id { get; set; }
    }
}
