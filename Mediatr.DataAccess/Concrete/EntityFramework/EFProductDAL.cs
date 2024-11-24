using Mediatr.Core.DataAccess.EntityFramework;
using Mediatr.DataAccess.Abstract;
using Mediatr.Entities.Concrete;
using Mediatr.Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.DataAccess.Concrete.EntityFramework
{
    public class EFProductDAL : EFRepositoryBase<Product, AppDbContext>, IProductDAL
    {
        public async Task CreateProductAsync(List<CreateProductDTO> models)
        {
            await using var context = new AppDbContext();

            var products = models.Select(dto => new Product
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
            }).ToList();

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid Id)
        {
            await using var context = new AppDbContext();

            var product = await context.Products.FindAsync(Id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public ICollection<GetProductDTO> GetAllProduct()
        {
            using var context = new AppDbContext();

            return context.Products.Select(p => new GetProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();
        }

        public GetProductDTO GetProduct(Guid Id)
        {
            using var context = new AppDbContext();

            var product = context.Products
                .Where(p => p.Id == Id)
                .Select(p => new GetProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                })
                .FirstOrDefault();

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            return product;
        }
    }
}
