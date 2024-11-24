using Mediatr.DataAccess.Concrete.EntityFramework;
using Mediatr.Entities.DTOs.CategoryDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.CategoryAction.Queries
{
    public class GetCategoriesByIdQueryHandler : IRequestHandler<GetCategoriesByIdQuery, IEnumerable<GetCategoryDTO>>
    {
        private readonly AppDbContext _context;

        public GetCategoriesByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCategoryDTO>> Handle(GetCategoriesByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(c => c.Id == request.Id).Select(c => new GetCategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                ProductName = c.Products.Select(p =>  p.Name).ToList()
            }).FirstOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                return Enumerable.Empty<GetCategoryDTO>();
            }

            return new List<GetCategoryDTO> { category };
        }
    }
}
