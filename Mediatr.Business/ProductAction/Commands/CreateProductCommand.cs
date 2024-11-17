using Mediatr.Entities.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Core.ProductAction.Commands
{
    public class CreateProductCommand : IRequest<CreateProductDTO>
    {
        public String Name { get; set; }
        public  decimal Price { get; set; }
    }
}
