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
    public class TicketsController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public TicketsController(CinemaDbContext context)
        {
            _context = context;
        }

        //GET: api/Tickets
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            return Ok(_context.Tickets.ToList());
        }

        //GET: api/Tickets/idNumber
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }



        // PUT: api/Tickets/{id}
        [HttpPut("{id}")]
        public ActionResult PutTicket(int id, TicketDto ticketDto)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
                return NotFound("Тікет не знайдено.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ticket.SeatNumber = ticketDto.SeatNumber;
            ticket.Price = ticketDto.Price;
            ticket.Status = ticketDto.Status;
            ticket.SessionId = ticketDto.SessionId;

            _context.SaveChanges();

            return NoContent();
        }



        // POST: api/Tickets
        [HttpPost]
        public ActionResult<Ticket> PostTicket(TicketDto ticketDto)
        {
            var sessionExists = _context.Sessions.Any(s => s.Id == ticketDto.SessionId);
            if (!sessionExists)
                return BadRequest($"Сессия с ID {ticketDto.SessionId} не найдена.");

            var ticket = new Ticket
            {
                SeatNumber = ticketDto.SeatNumber,
                Price = ticketDto.Price,
                Status = ticketDto.Status,
                SessionId = ticketDto.SessionId
            };

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
