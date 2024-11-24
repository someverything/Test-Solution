using Mediatr.DataAccess.Concrete.EntityFramework;
using Mediatr.Entities.Concrete;
using Mediatr.Entities.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.CategoryAction.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDTO>
    {
        private readonly AppDbContext _context;

        public CreateCategoryCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var createCategoryDTO = new CreateCategoryDTO
            {
                Name = category.Name
            };

            return createCategoryDTO;
        }
    }
}
