using Mediatr.Core.DataAccess.EntityFramework;
using Mediatr.Entities.Concrete;
using Mediatr.Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.DataAccess.Abstract
{
    public interface IProductDAL : IRepositoryBase<Product>
    {
        Task CreateProductAsync(List<CreateProductDTO> models);
        GetProductDTO GetProduct(Guid Id);
        ICollection<GetProductDTO> GetAllProduct();
        Task DeleteProduct(Guid Id);
    }
}
