using Cinema_ManagementSystem.Data;
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

        // GET: api/Sessions
        [HttpGet]
        public ActionResult<IEnumerable<Session>> GetSessions()
        {
            var sessions = _context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToList();
            return Ok(sessions);
        }

        // GET: api/Sessions/{id}
        [HttpGet("{id}")]
        public ActionResult<Session> GetSession(int id)
        {
            var session = _context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .FirstOrDefault(s => s.Id == id);

            return session == null ? NotFound() : Ok(session);
        }

        // PUT: api/Sessions/{id}
        [HttpPut("{id}")]
        public ActionResult PutSession(int id, Session session)
        {
            if (id != session.Id)
                return BadRequest("ID в URL та ID в тілі запиту не збігаються.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Entry(session).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(s => s.Id == id);
        }

        // POST: api/Sessions
        [HttpPost]
        public ActionResult<Session> PostSession(Session session)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

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
