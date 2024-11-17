using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.ProductAction.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductDTO>
    {
        public Guid Id { get; set; }
    }
}
