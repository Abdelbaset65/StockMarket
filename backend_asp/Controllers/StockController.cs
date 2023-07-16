using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_asp.Data;
using backend_asp.Models;
using backend_asp.Services;

namespace backend_asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockContext _context;
        private readonly StockService _stockService;
        // private readonly OrderService _orderService;

        public StockController(StockContext context, StockService stockService)
        {
            _context = context;
            _stockService = stockService;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
          if (_context.Stocks == null)
          {
              return NotFound();
          }
            return await _context.Stocks.ToListAsync();
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
          if (_context.Stocks == null)
          {
              return NotFound();
          }
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.ID)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
          if (_context.Stocks == null)
          {
              return Problem("Entity set 'StockContext.Stocks'  is null.");
          }
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.ID }, stock);
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return (_context.Stocks?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        // [HttpPost("/buy")]
        // public IActionResult BuyStock( string selectedstock, [FromBody] BuyRequest request)
        // {
        //     var stock = _stockService.GetStockByName(selectedstock);

        //     if (stock == null)
        //     {
        //         return NotFound();
        //     }

        //     _stockService.buyStock(stock.ID, request.Quantity, stock.Price, request.BuyerName);

        //     return Ok();
        // }

        [HttpPost("{stockID}/buy")]
        public IActionResult BuyStock([FromBody] Order order)
        {
            var stock = _stockService.GetStock(order.StockID);

            if (stock == null)
            {
                return NotFound();
            }

            _stockService.buyStock(order);

            return Ok();
        }
    }
}