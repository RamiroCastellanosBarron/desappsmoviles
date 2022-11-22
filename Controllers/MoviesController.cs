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
        public async Task<ActionResult<JsonArray>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            var jsonArray = new JsonArray()
            {
                Movies = movies,
            };

            return Ok(jsonArray);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JsonObject>> GetMovie(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            var json = new JsonObject() { Movie = movie };

            return Ok(json);
        }
    }

    public class JsonArray
    {
        public IEnumerable<Movie> Movies { get; set; }
    }

    public class JsonObject
    {
        public Movie Movie { get; set; }
    }

}
