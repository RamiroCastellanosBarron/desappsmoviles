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
        public async Task<ActionResult<JsonMovieResponse>> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(movie);

            await _context.SaveChangesAsync();

            var result = new JsonMovieResponse()
            {
                Response = "Movie of id " + id + " was deleted successfuly",
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<JsonMovieResponse>> InsertMovie(MovieDto movieDto)
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

            var result = new JsonMovieResponse()
            {
                Response = "Movie of title " + movieDto.Title + " was added successfully",
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JsonMovieResponse>> UpdateMovie(MovieDto movieDto, int id)
        {
            var movie = await _context.Movies
                .SingleOrDefaultAsync(x => x.Id == id);

            movie.ReleaseDate = movieDto.ReleaseDate;
            movie.Title = movieDto.Title;
            movie.Runtime = movieDto.Runtime;
            movie.Overview = movieDto.Overview;
            movie.PhotoUrl = movieDto.PhotoUrl;
            movie.Revenue = movieDto.Revenue;
            movie.VoteAverage = movie.VoteAverage;

            await _context.SaveChangesAsync();

            var result = new JsonMovieResponse()
            {
                Response = "Movie of title " + movieDto.Title + " was updated successfully",
            };

            return Ok(result);
        }
    }

    public class JsonMovieResponse
    {
        public string Response { get; set; }
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
