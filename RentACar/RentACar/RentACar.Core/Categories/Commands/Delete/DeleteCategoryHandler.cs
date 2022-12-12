using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Categories.Commands.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, Category>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteCategoryHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Category> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var category = await this.uniteOfWorkRepo.CategoryRepository.GetByIdAsync(request.Id);

            if (!category.IsDeleted)
            {
                category.IsDeleted = true;
            }
            else
            {
                throw new InvalidOperationException("This category is already deleted");
            }

            return category;
        }
    }
}
