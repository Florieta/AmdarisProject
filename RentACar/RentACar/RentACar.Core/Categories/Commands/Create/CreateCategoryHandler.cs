using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entitites;
using MediatR;
using RentACar.Application.Abstract;

namespace RentACar.Application.Categories.Commands.Create
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Category>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public CreateCategoryHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Category> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                CategoryName = request.CategoryName
            };

            await this.unitOfWorkRepo.CategoryRepository.AddAsync(category);
            await this.unitOfWorkRepo.SaveAsync();

            return category;
        }
    }
}
