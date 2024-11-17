using Mediatr.Business.ProductAction.Queries;
using Mediatr.Core.ProductAction.Commands;
using Mediatr.Core.ProductAction.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };

            var result = await _mediator.Send(query);

            if(result ==null) return NotFound();

            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            if (command == null) return BadRequest("Invalid product data!");

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductByIdAsync), new {id = result.Id}, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var query = new GetAllProductsQuery();

            var resul = await _mediator.Send(query);
            if(resul == null) return NotFound();
            return Ok(resul);
        }
    }
}
