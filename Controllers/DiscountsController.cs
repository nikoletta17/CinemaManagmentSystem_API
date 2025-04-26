using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public DiscountsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Discounts
        [HttpGet]
        public ActionResult<IEnumerable<Discount>> GetDiscounts()
        {
            return _context.Discounts.ToList();
        }

        // GET: api/Discounts/idNumber
        [HttpGet("{id}")]
        public ActionResult<Discount> GetDiscount(int id)
        {
            var discount = _context.Discounts.Find(id);
            return discount == null ? NotFound() : Ok(discount);
        }

        // PUT: api/Discounts/idNumber
        [HttpPut("{id}")]
        public IActionResult PutDiscount(int id, Discount discount)
        {
            if (id != discount.Id)
            {
                return BadRequest();
            }

            _context.Entry(discount).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(id))
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

        private bool DiscountExists(int id)
        {
            return _context.Discounts.Any(e => e.Id == id);
        }

        // POST: api/Discounts
        [HttpPost]
        public ActionResult<Discount> PostDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDiscount), new { id = discount.Id }, discount);
        }

        // DELETE: api/Discounts/idNumber
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var discount = _context.Discounts.Find(id);
            if (discount == null)
                return NotFound();

            _context.Discounts.Remove(discount);
            _context.SaveChanges();

            return NoContent();
        }

    }
}