using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Data;
using movies.Entities;

namespace movies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            if (movies == null) return NoContent();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Json>> GetMovie(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            var json = new Json() { Movie = movie };

            return Ok(json);
        }
    }

    public class Json
    {
        public Movie Movie { get; set; }
    }

}
