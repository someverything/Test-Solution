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
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetCategoryDTO>>
    {
        private readonly AppDbContext _context;

        public GetAllCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Select(category => new GetCategoryDTO
                {
                    Name = category.Name,
                    ProductName = category.Products.Select(product => product.Name).ToList()
                }).ToListAsync();
        }
    }
}
