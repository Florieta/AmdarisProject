using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Abstract
{
    public interface IInsuranceRepository
    {
        Task<Insurance> GetById(int insuranceId);

        Task Add(Insurance insurance);

        void Remove(Insurance insurance);

        Task<List<Insurance>> GetAll();

        Task Update(Insurance insurance);
    }
}
