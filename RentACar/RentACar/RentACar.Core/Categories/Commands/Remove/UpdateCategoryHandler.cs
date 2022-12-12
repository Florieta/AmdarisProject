using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Categories.Commands.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, Category>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public UpdateCategoryHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Category> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Id = request.Id,
                CategoryName = request.CategoryName,
            };

            await this.uniteOfWorkRepo.CategoryRepository.Update(category);
            await this.uniteOfWorkRepo.SaveAsync();

            return category;
        }
    }
}
