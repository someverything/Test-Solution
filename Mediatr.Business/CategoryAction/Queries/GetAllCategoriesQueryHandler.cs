using Mediatr.DataAccess.Concrete.EntityFramework;
using Mediatr.Entities.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Business.CategoryAction.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetCategoryDTO>>
    {
        private readonly AppDbContext _context;

        public GetAllCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<GetCategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
