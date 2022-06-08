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
    public class CategoryProductsController : ControllerBase
    {
        private readonly TiendaApp_BackendContext _context;

        public CategoryProductsController(TiendaApp_BackendContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProduct()
        {
          if (_context.CategoryProduct == null)
          {
              return NotFound();
          }
            return await _context.CategoryProduct.ToListAsync();
        }

        // GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProduct>> GetCategoryProduct(int id)
        {
          if (_context.CategoryProduct == null)
          {
              return NotFound();
          }
            var categoryProduct = await _context.CategoryProduct.FindAsync(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return categoryProduct;
        }

        // PUT: api/CategoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProduct(int id, CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryProduct>> PostCategoryProduct(CategoryProduct categoryProduct)
        {
          if (_context.CategoryProduct == null)
          {
              return Problem("Entity set 'TiendaApp_BackendContext.CategoryProduct'  is null.");
          }
            _context.CategoryProduct.Add(categoryProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryProductExists(categoryProduct.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.CategoryID }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5/4
        [HttpDelete("{categoryId}/{productId}")]
        public async Task<IActionResult> DeleteCategoryProduct(int categoryId, int productId)
        {
            if (_context.CategoryProduct == null)
            {
                return NotFound();
            }

            var categoryProduct = await _context.CategoryProduct.FindAsync(categoryId, productId);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProduct.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryProductExists(int id)
        {
            return (_context.CategoryProduct?.Any(e => e.CategoryID == id)).GetValueOrDefault();
        }
    }
}
