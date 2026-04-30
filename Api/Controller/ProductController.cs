using Application.DTOs;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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

        
        [HttpPost("/create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            try
            {
                var product = new Product
                {
                    Code = dto.Code,
                    Name = dto.Name,
                    Price = dto.Price,
                    Stock = dto.Stock
                };

                var result = await _service.Create(product);

                return Created("", new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = "Producto creado correctamente",
                    Data = new ProductResponseDto
                    {
                        Id = result.Id,
                        Code = result.Code,
                        Name = result.Name,
                        Price = result.Price,
                        Stock = result.Stock
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        
        [HttpGet("findAll")]
        public async Task<IActionResult> GetAll(int page = 1, int size = 10)
        {
            var products = await _service.GetAll(page, size);

            var response = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });

            return Ok(new ApiResponse<IEnumerable<ProductResponseDto>>
            {
                Success = true,
                Message = "Listado de productos",
                Data = response
            });
        }

        
        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var p = await _service.GetById(id);

                return Ok(new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = "Producto encontrado",
                    Data = new ProductResponseDto
                    {
                        Id = p.Id,
                        Code = p.Code,
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no encontrado"))
                    return NotFound(new ApiResponse<object> { Success = false, Message = ex.Message });

                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var p = await _service.GetByCode(code);

                return Ok(new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = "Producto encontrado",
                    Data = new ProductResponseDto
                    {
                        Id = p.Id,
                        Code = p.Code,
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no encontrado"))
                    return NotFound(new ApiResponse<object> { Success = false, Message = ex.Message });

                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        
        [HttpPut("/stock/{id}")]
        public async Task<IActionResult> UpdateStock(int id, int quantity)
        {
            try
            {
                await _service.UpdateStock(id, quantity);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Stock actualizado correctamente"
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no encontrado"))
                    return NotFound(new ApiResponse<object> { Success = false, Message = ex.Message });

                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            try
            {
                var result = await _service.Update(id, dto);

                return Ok(new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = "Producto actualizado correctamente",
                    Data = new ProductResponseDto
                    {
                        Id = result.Id,
                        Code = result.Code,
                        Name = result.Name,
                        Price = result.Price,
                        Stock = result.Stock
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no encontrado"))
                    return NotFound(new ApiResponse<object> { Success = false, Message = ex.Message });

                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }
    }
}