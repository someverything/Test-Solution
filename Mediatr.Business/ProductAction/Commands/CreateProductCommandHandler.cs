using Mediatr.DataAccess.Abstract.EntityFramework;
using Mediatr.Entities.Concrete;
using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Core.ProductAction.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDTO>
    {
        private readonly AppDbContext _context;

        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var CreateProductDTO = new CreateProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };

            return CreateProductDTO;
        }
    }
}
