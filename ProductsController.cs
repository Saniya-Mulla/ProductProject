using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTaskManager.Data;
using MvcTaskManager.Models;

namespace MvcTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            var projs = await _context.Products.ToListAsync();
            return Ok(projs);
        }

        
        [HttpPut]
        public async Task<ActionResult<List<Products>>> UpdateProduct(Products prod)
        {
            var existingProduct = await _context.Products.FindAsync(prod.ProductId);
            if (existingProduct == null)
                return BadRequest("Product not found.");

            existingProduct.ProductName = prod.ProductName;
            existingProduct.CreatedDate = prod.CreatedDate;
            existingProduct.Quantity = prod.Quantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Products>>> DeleteProducts(int id)
        {
            var delProd = await _context.Products.FindAsync(id);
            if (delProd == null)
                return BadRequest("Product not found.");

            _context.Products.Remove(delProd);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> AddProducts(Products prod)
        {
            _context.Products.Add(prod);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
    }
}
