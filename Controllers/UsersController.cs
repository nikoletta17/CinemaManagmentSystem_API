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
    public class UsersController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public UsersController(CinemaDbContext context)
        {
            _context = context;
        }

        //GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //GET: api/Users/idNumber
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user == null ? NotFound() : Ok(user);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound($"Користувач з ID {id} не знайдений.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.UserType = userDto.UserType;
            user.Bonuses = userDto.Bonuses;

            _context.SaveChanges();

            return NoContent();
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                UserType = userDto.UserType,
                Bonuses = userDto.Bonuses
            };

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
