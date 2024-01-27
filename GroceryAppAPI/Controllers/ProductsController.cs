using GroceryAppAPI.Attributes;
using GroceryAppAPI.Models;
using GroceryAppAPI.Services;
using GroceryAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CommonExceptionFilter]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var id = _productService.Add(product);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Product product) 
        {
            _productService.Update(id, product);
            return Ok(new {Message = "Product updated successfully."});    
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productService.Delete(id);
            return Ok(new { Message = "Product deleted successfully." });
        }
    }
}
