using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public ICollection<Car> Cars { get; init; } = new List<Car>();

    }
}
