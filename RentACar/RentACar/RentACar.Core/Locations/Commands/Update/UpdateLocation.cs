using MediatR;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Commands.Update
{
    public class UpdateLocation : IRequest<Location>
    {
        public int Id { get; set; }
        public string LocationName { get; set; } = null!;

        public string Address { get; set; } = null!;

    }
}
