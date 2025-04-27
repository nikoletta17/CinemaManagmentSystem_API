using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaManagementSystem.DTOs;

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

        // GET: api/Halls/{id}
        [HttpGet("{id}")]
        public ActionResult<Hall> GetHall(int id)
        {
            var hall = _context.Halls.Find(id);
            return hall == null ? NotFound() : Ok(hall); // 200 or 404
        }

        // PUT: api/Halls/{id}
        [HttpPut("{id}")]
        public ActionResult PutHall(int id, HallDto hallDto)
        {
            var hall = _context.Halls.Find(id);
            if (hall == null)
                return NotFound();

            hall.HallNumber = hallDto.HallNumber;
            hall.SeatsCount = hallDto.SeatsCount;
            hall.HallType = hallDto.HallType;

            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Halls
        [HttpPost]
        public ActionResult<Hall> PostHall(HallDto hallDto)
        {
            var hall = new Hall
            {
                HallNumber = hallDto.HallNumber,
                SeatsCount = hallDto.SeatsCount,
                HallType = hallDto.HallType
            };

            _context.Halls.Add(hall);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHall), new { id = hall.Id }, hall);
        }

        // DELETE: api/Halls/{id}
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
