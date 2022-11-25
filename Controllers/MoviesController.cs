using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using movies.Data;
using movies.DTOs;
using movies.Entities;
using System.Security.Principal;

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
            var movies = await _context.Movies
                .ToListAsync();

            return Ok(movies);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            return Ok(movie);
        }

        // DELETE
        [HttpGet("delete/{id}")]
        public async Task<ActionResult<JsonResponse>> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(movie);

            await _context.SaveChangesAsync();

            return Ok(new JsonResponse { Code = "OK"});
        }

        // ADD
        [HttpGet("insert")]
        public async Task<ActionResult<JsonResponse>> InsertMovie([FromQuery]MovieDto movieDto)
        {
            var movie = new Movie()
            {
                Title = movieDto.Title,
                PhotoUrl = movieDto.PhotoUrl,
                ReleaseDate = movieDto.ReleaseDate,
                Runtime = movieDto.Runtime,
                Overview = movieDto.Overview,
                Revenue = movieDto.Revenue,
                VoteAverage = movieDto.VoteAverage,
            };

            await _context.Movies.AddAsync(movie);

            await _context.SaveChangesAsync();

            return Ok(new JsonResponse { Code = "OK" });
        }

        // UPDATE
        [HttpGet("update")]
        public async Task<ActionResult<JsonResponse>> UpdateMovie([FromQuery]MovieDto movieDto)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == movieDto.Id);

            movie.ReleaseDate = movieDto.ReleaseDate;
            movie.Title = movieDto.Title;
            movie.Runtime = movieDto.Runtime;
            movie.Overview = movieDto.Overview;
            movie.PhotoUrl = movieDto.PhotoUrl;
            movie.Revenue = movieDto.Revenue;
            movie.VoteAverage = movie.VoteAverage;

            await _context.SaveChangesAsync();

            return Ok(new JsonResponse { Code = "OK" });
        }
    }

    public class JsonResponse
    {
        public string Code { get; set; }
    }

}
