using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using movies.Data;
using movies.DTOs;
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
            var movies = await _context.Movies
                .ToListAsync();

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(movie);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JsonObject>> InsertMovie(MovieDto movieDto)
        {
            var movie = new Movie()
            {
                Title = movieDto.Title,
                PhotoUrl = movieDto.PhotoUrl,
                ReleaseDate = movieDto.ReleaseDate,
                Runtime = movieDto.Runtime,
                Overview = movieDto.Overview,
                Budget = movieDto.Budget,
                Revenue = movieDto.Revenue,
            };

            await _context.Movies.AddAsync(movie);

            await _context.SaveChangesAsync();

            JsonObject movieJson = new JsonObject()
            {
                Movie = movie
            };

            return Ok(movieJson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(MovieDto movieDto, int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == id);

            movie.ReleaseDate = movieDto.ReleaseDate;
            movie.Title = movieDto.Title;
            movie.Runtime = movieDto.Runtime;
            movie.Overview = movieDto.Overview;
            movie.PhotoUrl = movieDto.PhotoUrl;
            movie.Budget = movieDto.Budget;
            movie.Revenue = movieDto.Revenue;

            await _context.SaveChangesAsync();

            return Ok();
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
