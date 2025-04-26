using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public UsersController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users
                .Include(u => u.Sales)   // Завантажуємо продажі, пов'язані з користувачем
                .Include(u => u.Tickets) // Завантажуємо квитки, пов'язані з користувачем
                .ToList();

            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users
                .Include(u => u.Sales)
                .Include(u => u.Tickets)
                .FirstOrDefault(u => u.Id == id);

            return user == null ? NotFound($"Користувач з ID {id} не знайдений.") : Ok(user);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest("ID в URL та ID в тілі запиту не збігаються.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound($"Користувач з ID {id} не знайдений.");

                throw;
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Перевірка на валідність моделі

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound($"Користувач з ID {id} не знайдений.");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
