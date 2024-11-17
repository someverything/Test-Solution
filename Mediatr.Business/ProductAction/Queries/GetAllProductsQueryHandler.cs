using Mediatr.Core.ProductAction.Commands;
using Mediatr.DataAccess.Abstract.EntityFramework;
using Mediatr.Entities.Concrete;
using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Core.ProductAction.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductDTO>>
    {
        private readonly AppDbContext _context;

        public GetAllProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var GetProductDTOs = await _context.Products
                .Select(p => new GetProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToListAsync(cancellationToken);

            return GetProductDTOs;
        }
    }
}
