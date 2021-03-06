using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaApp_Backend.Data;
using TiendaApp_Backend.Models;

namespace TiendaApp_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly TiendaApp_BackendContext _context;

        public ProductsController(TiendaApp_BackendContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/Categories/5
        [HttpGet("categories/{categoryID}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategoryId(int categoryID)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(categoryID);

            if (category == null)
            {
                return NotFound();
            }

            List<Product> productsByCategoryId =
                (from product in _context.Product
                 join categoryProduct in _context.CategoryProduct on product.ProductID equals categoryProduct.ProductID
                 where categoryProduct.CategoryID == categoryID
                 select new Product
                 {
                     ProductID = product.ProductID,
                     ProductName = product.ProductName,
                     ProductPrice = product.ProductPrice
                 }).ToList();

            if (productsByCategoryId == null)
            {
                return NotFound();
            }

            return productsByCategoryId;
        }

        // GET: api/Products/Categories/missing/5
        [HttpGet("categories/not/{categoryID}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsNotInCategory(int categoryID)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(categoryID);

            if (category == null)
            {
                return NotFound();
            }

            List<Product> productsNotInCategory = _context.Product
                .FromSqlRaw(
                    "SELECT * FROM Product " +
                    "WHERE ProductID NOT IN(" +
                    "   SELECT ProductID FROM CategoryProduct " +
                    "   WHERE CategoryID = {0}" +
                    ");", categoryID)
                .ToList();

            if (productsNotInCategory == null)
            {
                return NotFound();
            }

            return productsNotInCategory;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Product == null)
          {
              return Problem("Entity set 'TiendaApp_BackendContext.Product'  is null.");
          }
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
