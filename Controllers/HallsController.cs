using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public HallsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Halls
        [HttpGet]
        public ActionResult<IEnumerable<Hall>> GetHalls()
        {
            return Ok(_context.Halls.ToList()); // 200
        }

        // GET: api/Halls/idNumber
        [HttpGet("{id}")]
        public ActionResult<Hall> GetHall(int id)
        {
            var hall = _context.Halls.Find(id);
            return hall == null ? NotFound() : Ok(hall); // 200 or 404
        }

        // PUT: api/Halls/idNumber
        [HttpPut("{id}")]
        public ActionResult PutHall(int id, Hall hall)
        {
            if (id != hall.Id)
                return BadRequest(); // 400

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Entry(hall).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HallExists(id))
                {
                    return NotFound(); // 404
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // 204
        }

        private bool HallExists(int id)
        {
            return _context.Halls.Any(h => h.Id == id); // Перевірка існування зали
        }

        // POST: api/Halls
        [HttpPost]
        public ActionResult<Hall> PostHall(Hall hall)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Halls.Add(hall);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHall), new { id = hall.Id }, hall); // 201
        }

        // DELETE: api/Halls/idNumber
        [HttpDelete("{id}")]
        public ActionResult DeleteHall(int id)
        {
            var hall = _context.Halls.Find(id);
            if (hall == null)
                return NotFound(); // 404

            _context.Halls.Remove(hall);
            _context.SaveChanges();

            return NoContent(); // 204
        }
    }
}
