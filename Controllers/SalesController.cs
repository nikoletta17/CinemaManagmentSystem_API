using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.DTOs;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public SalesController(CinemaDbContext context)
        {
            _context = context;
        }

        //GET: api/Sales
        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetSales()
        {
            return Ok(_context.Sales.ToList());
        }

        //GET: api/Sales/idNumber
        [HttpGet("{id}")]
        public ActionResult<Sale> GetSale(int id)
        {
            var sale = _context.Sales.Find(id);
            return sale == null ? NotFound() : Ok(sale);
        }

        // PUT: api/Sales/idNumber
        [HttpPut("{id}")]
        public ActionResult PutSale(int id, SaleDto saleDto)
        {
            var sale = _context.Sales.Find(id);
            if (sale == null)
                return NotFound();

            sale.TicketsCount = saleDto.TicketsCount;
            sale.TotalAmount = saleDto.TotalAmount;
            sale.PurchaseDate = saleDto.PurchaseDate;
            sale.DiscountId = saleDto.DiscountId;
            sale.UserId = saleDto.UserId;

            _context.SaveChanges();
            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(s => s.Id == id);
        }

        // POST: api/Sales
        [HttpPost]
        public ActionResult<Sale> PostSale(SaleDto saleDto)
        {
            var sale = new Sale
            {
                TicketsCount = saleDto.TicketsCount,
                TotalAmount = saleDto.TotalAmount,
                PurchaseDate = saleDto.PurchaseDate,
                DiscountId = saleDto.DiscountId,
                UserId = saleDto.UserId
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }


        // DELETE: api/Sales/idNumber
        [HttpDelete("{id}")]
        public ActionResult DeleteSale(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale == null)
                return NotFound();

            _context.Sales.Remove(sale);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
