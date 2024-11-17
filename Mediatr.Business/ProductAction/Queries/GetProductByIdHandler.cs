using Mediatr.DataAccess.Abstract.EntityFramework;
using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.ProductAction.Queries
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        private readonly AppDbContext _context;

        public GetProductByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == request.Id).Select(p => new GetProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).FirstOrDefaultAsync(cancellationToken);

            return product;
        }
    }
}
