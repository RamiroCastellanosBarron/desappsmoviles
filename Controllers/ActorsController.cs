using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Data;
using movies.Entities;

namespace movies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly DataContext _context;

        public ActorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JsonArrayActors>>> GetActors()
        {
            var actors = await _context.Persons
                .ToListAsync();

            var movies = await _context.Movies
                .ToListAsync();

            var jsonArray = new JsonArrayActors() { Actors = actors };

            return Ok(jsonArray);
        }
    }

    public class ActorsQuery
    {
        public Person Actor { get; set; }
        public Gender Gender { get; set; }
    }

    public class JsonArrayActors
    {
        public IEnumerable<Person> Actors { get; set; }
    }

    public class JsonObjectActor
    {
        public Person Actor { get; set; }
    }
}
