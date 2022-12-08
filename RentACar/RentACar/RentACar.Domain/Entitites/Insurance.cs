using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entitites
{
    public class Insurance
    {
        public int InsuranceCode { get; set; }
        public string TypeOfInsurance { get; set; } = null!;
        public decimal CostPerDay { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
