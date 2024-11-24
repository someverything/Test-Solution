using Mediatr.Entities.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.CategoryAction.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryDTO>
    {
        public string Name { get; set; }
    }
}
