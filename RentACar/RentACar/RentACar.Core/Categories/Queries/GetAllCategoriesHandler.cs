using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Categories.Queries
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, List<Category>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Category>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.CategoryRepository.GetAllAsync();
        }
    }
}
