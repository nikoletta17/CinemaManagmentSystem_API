using Cinema_ManagementSystem.Data;
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

        // GET: api/Sales
        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetSales()
        {
            return Ok(_context.Sales.Include(s => s.User).Include(s => s.Discount).ToList());
        }

        // GET: api/Sales/idNumber
        [HttpGet("{id}")]
        public ActionResult<Sale> GetSale(int id)
        {
            var sale = _context.Sales.Include(s => s.User).Include(s => s.Discount).FirstOrDefault(s => s.Id == id);
            return sale == null ? NotFound() : Ok(sale);
        }

        // PUT: api/Sales/idNumber
        [HttpPut("{id}")]
        public ActionResult PutSale(int id, Sale sale)
        {
            if (id != sale.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Entry(sale).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(s => s.Id == id);
        }

        // POST: api/Sales
        [HttpPost]
        public ActionResult<Sale> PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

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
