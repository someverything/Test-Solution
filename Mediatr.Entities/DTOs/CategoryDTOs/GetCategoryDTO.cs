using Mediatr.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Entities.DTOs.CategoryDTOs
{
    public class GetCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<String> ProductName { get; set; }
    }
}
