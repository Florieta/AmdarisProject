using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Commands.Add
{
    public class AddCategoryToCarHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCategoryToCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(AddCategoryToCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetByIdAsync(request.CarId);
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

            if (car == null || category == null)
            {
                return null;
            }

            car.CategoryId = request.CategoryId;
            await _unitOfWork.SaveAsync();

            return car;
        }
    }
}
