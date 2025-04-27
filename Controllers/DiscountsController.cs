using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.DTOs;
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

        // PUT: api/Discounts/{id}
        [HttpPut("{id}")]
        public ActionResult PutDiscount(int id, DiscountDto discountDto)
        {
            var discount = _context.Discounts.Find(id);
            if (discount == null)
                return NotFound($"Знижку з ID {id} не знайдено.");

            // Оновлюємо тільки потрібні поля
            discount.Description = discountDto.Description;
            discount.Percentage = discountDto.Percentage;

            _context.SaveChanges();

            return NoContent();
        }


        private bool DiscountExists(int id)
        {
            return _context.Discounts.Any(e => e.Id == id);
        }

        // POST: api/Discounts
        [HttpPost]
        public ActionResult<Discount> PostDiscount(DiscountDto discountDto)
        {
            var discount = new Discount
            {
                Description = discountDto.Description,
                Percentage = discountDto.Percentage
            };

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