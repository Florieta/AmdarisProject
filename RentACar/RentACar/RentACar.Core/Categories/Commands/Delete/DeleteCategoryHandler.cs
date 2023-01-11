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
    public class DeleteLocationHandler : IRequestHandler<DeleteLocation, Category>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteLocationHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Category> Handle(DeleteLocation request, CancellationToken cancellationToken)
        {
            var category = await this.uniteOfWorkRepo.CategoryRepository.GetByIdAsync(request.Id);

            if (category.IsDeleted)
            {
                throw new InvalidOperationException("This category is already deleted");
            }
            
            this.uniteOfWorkRepo.CategoryRepository.Remove(category);
            await this.uniteOfWorkRepo.SaveAsync();

            return category;
        }
    }
}
