using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Core.ProductAction.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetProductDTO>>
    {
    }
}
