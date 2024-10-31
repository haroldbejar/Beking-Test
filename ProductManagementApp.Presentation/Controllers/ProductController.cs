using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Application.Services;
using ProductManagementApp.Domain.DTOs;

namespace ProductManagementApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try 
            {
                var products = await _service.GetAllAsync();
                return Ok(products);
            } catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getproductbycategory/category")]
        public async Task<IActionResult> GetProductByCategory([FromQuery] string category)
        {
            try
            {
                var products = await _service.GetByCategoryAsync(category);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto, [FromHeader] string role) 
        {
            try
            {
                await _service.InsertAsync(productDto, role);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }
    }
}