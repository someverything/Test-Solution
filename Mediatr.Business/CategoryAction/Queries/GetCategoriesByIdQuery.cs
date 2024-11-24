using Mediatr.Entities.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.CategoryAction.Queries
{
    public class GetCategoriesByIdQuery : IRequest<IEnumerable<GetCategoryDTO>>
    {
        public Guid Id { get; set; }
    }
}
