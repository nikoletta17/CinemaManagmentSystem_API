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
    public class SessionsController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public SessionsController(CinemaDbContext context)
        {
            _context = context;
        }

        //GET: api/Sessions
        [HttpGet]
        public ActionResult<IEnumerable<Session>> GetSessions()
        {
            return Ok(_context.Sessions.ToList());
        }

        //GET: api/Sessions/idNumber
        [HttpGet("{id}")]
        public ActionResult<Session> GetSession(int id)
        {
            var session = _context.Sessions.Find(id);
            return session == null ? NotFound() : Ok(session);
        }


        // PUT: api/Sessions/{id}
        [HttpPut("{id}")]
        public ActionResult PutSession(int id, SessionDto sessionDto)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session == null)
                return NotFound($"Сесія з ID {id} не знайдена.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            session.DateTime = sessionDto.DateTime;
            session.TicketPrice = sessionDto.TicketPrice;
            session.Status = sessionDto.Status;
            session.MovieId = sessionDto.MovieId;
            session.HallId = sessionDto.HallId;

            _context.SaveChanges();

            return NoContent();
        }

        //метод, который будет автоматически менять статус всех сеансов, если их время прошло.
        [HttpPut("update-status")]
        public ActionResult UpdateSessionsStatus()
        {
            var now = DateTime.Now;

            var sessionsToUpdate = _context.Sessions
                .Where(s => s.DateTime <= now && s.Status == "Scheduled")
                .ToList();

            foreach (var session in sessionsToUpdate)
            {
                session.Status = "Finished";
            }

            _context.SaveChanges();

            return Ok($"Обновлено {sessionsToUpdate.Count} сеансов.");
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(s => s.Id == id);
        }

        // POST: api/Sessions
        [HttpPost]
        public ActionResult<Session> PostSession(SessionDto sessionDto)
        {
            var session = new Session
            {
                DateTime = sessionDto.DateTime,
                TicketPrice = sessionDto.TicketPrice,
                Status = sessionDto.Status,
                MovieId = sessionDto.MovieId,
                HallId = sessionDto.HallId
            };

            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
        }


        // DELETE: api/Sessions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session == null)
                return NotFound();

            _context.Sessions.Remove(session);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
