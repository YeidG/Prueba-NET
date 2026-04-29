using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int size = 10)
        {
            return Ok(await _service.GetAll(page, size));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("{id}/stock")]
        public async Task<IActionResult> UpdateStock(Guid id, int quantity, bool increase)
        {
            await _service.UpdateStock(id, quantity, increase);
            return NoContent();
        }
    }
}
