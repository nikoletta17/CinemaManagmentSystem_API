using Cinema_ManagementSystem.Data;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public MoviesController(CinemaDbContext context)
        {
            _context = context;
        }

        //GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>>GetMovies()
        {
            return Ok(_context.Movies.ToList());
        }

        //GET: api/Movies/idNumber
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        //PUT: api/Movies/idNumber
        [HttpPut("{id}")]
        public ActionResult PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();


            _context.Entry(movie).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                    return NotFound();

                throw;
            }
            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }

        //POST: api/Movies
        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        //DELETE: api/Movies/idNumber
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();


            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
