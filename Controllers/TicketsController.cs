using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public TicketsController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = _context.Tickets
                .Include(t => t.Session) // Завантажуємо пов'язану сесію
                .ThenInclude(s => s.Movie) // Завантажуємо фільм для сесії
                .ToList();
            return Ok(tickets);
        }

        // GET: api/Tickets/{id}
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            var ticket = _context.Tickets
                .Include(t => t.Session) // Завантажуємо пов'язану сесію
                .FirstOrDefault(t => t.Id == id);

            return ticket == null ? NotFound() : Ok(ticket);
        }

        // PUT: api/Tickets/{id}
        [HttpPut("{id}")]
        public ActionResult PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest("ID в URL та ID в тілі запиту не збігаються.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Entry(ticket).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                    return NotFound("Тікет не знайдено.");

                throw;
            }

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(t => t.Id == id);
        }

        // POST: api/Tickets
        [HttpPost]
        // POST: api/Tickets
        [HttpPost]
        public ActionResult<Ticket> PostTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var sessionExists = _context.Sessions.Any(s => s.Id == ticket.SessionId);
            if (!sessionExists)
                return BadRequest($"Сесія з ID {ticket.SessionId} не знайдена.");

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
                return NotFound("Тікет не знайдено.");

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
