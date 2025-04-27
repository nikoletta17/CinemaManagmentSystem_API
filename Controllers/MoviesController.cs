using CinemaManagementSystem.DTOs;
using CinemaManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema_ManagementSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagmentSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public MoviesController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Halls
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(_context.Movies.ToList());
        }

        // GET: api/Halls/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        // POST: api/Halls
        [HttpPost]
        public ActionResult<Movie> PostMovie(MovieDto movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                Director = movieDto.Director,
                DurationMinutes = movieDto.DurationMinutes,
                ReleaseYear = movieDto.ReleaseYear,
                AgeRestriction = movieDto.AgeRestriction,
                Description = movieDto.Description
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/Halls/{id}
        [HttpPut("{id}")]
        public ActionResult PutMovie(int id, MovieDto movieDto)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            movie.Title = movieDto.Title;
            movie.Genre = movieDto.Genre;
            movie.Director = movieDto.Director;
            movie.DurationMinutes = movieDto.DurationMinutes;
            movie.ReleaseYear = movieDto.ReleaseYear;
            movie.AgeRestriction = movieDto.AgeRestriction;
            movie.Description = movieDto.Description;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Halls/{id}
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
