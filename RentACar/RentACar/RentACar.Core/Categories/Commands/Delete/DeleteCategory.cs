using MediatR;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Categories.Commands.Delete
{
    public class DeleteLocation : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
