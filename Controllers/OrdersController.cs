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
    public class OrdersController : ControllerBase
    {
        private readonly TiendaApp_BackendContext _context;

        public OrdersController(TiendaApp_BackendContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
          if (_context.Order == null)
          {
              return NotFound();
          }
          return await _context.Order.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Order == null)
          {
              return NotFound();
          }
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET: api/Orders/detail/5
        [HttpGet("detail/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetailReport>>> GetOrderDetail(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }

            // Get all info of Order, OrderDetail and Product
            List<OrderDetailReport> orderDetailReport =
                (from orderDetail in _context.OrderDetail
                join order in _context.Order on orderDetail.OrderID equals order.OrderID
                join product in _context.Product on orderDetail.ProductID equals product.ProductID
                join client  in _context.Client on order.ClientID equals client.ClientID
                where orderDetail.OrderID == id
                select new OrderDetailReport
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate,
                    OrderTotal = order.OrderTotal,
                    ClientID = client.ClientID,
                    ClientName = client.ClientName,
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    OrderQuantity = orderDetail.OrderQuantity,
                    OrderTotalProduct = orderDetail.OrderTotalProduct
                }).ToList();

            if (orderDetailReport == null)
            {
                return NotFound();
            }

            return orderDetailReport;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Cart cart)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'TiendaApp_BackendContext.Order'  is null.");
            }

            // Get total for every product (they're saved in order)
            var productTotal = cart.ProductsID.Select((productId, i) => _context.Product.Find(productId).ProductPrice * cart.Quantity[i]).ToList();

            // Create order
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderTotal = productTotal.Sum();
            order.ClientID = cart.ClientID;

            _context.Order.Add(order);
            _context.SaveChanges(); // Important to save in db to get Id later

            // Create OrderDetail
            OrderDetail orderDetail;
            for (int i = 0; i < cart.ProductsID.Length; i++)
            {
                orderDetail = new OrderDetail();
                orderDetail.OrderID = order.OrderID;
                orderDetail.ProductID = cart.ProductsID[i];
                orderDetail.OrderQuantity = cart.Quantity[i];
                orderDetail.OrderTotalProduct = productTotal[i];
                _context.OrderDetail.Add(orderDetail);
            }
            _context.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
