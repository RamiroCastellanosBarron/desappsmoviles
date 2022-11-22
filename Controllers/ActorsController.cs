using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Data;
using movies.DTOs;
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

            var jsonArray = new JsonArrayActors() { Actors = actors };

            return Ok(jsonArray);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JsonObjectActor>> GetActor(int id)
        {
            var actor = await _context.Persons
                .SingleOrDefaultAsync(x => x.Id == id);

            var jsonObject = new JsonObjectActor() { Actor= actor };

            return Ok(jsonObject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            var actor = await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);

            _context.Persons.Remove(actor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActor(ActorDto actorDto, int id)
        {
            var actor = await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);

            actor.Name = actorDto.Name;
            actor.PhotoUrl= actorDto.PhotoUrl;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> InsertActor(ActorDto actorDto)
        {
            var actor = new Person() { Name=actorDto.Name, PhotoUrl=actorDto.PhotoUrl };

            await _context.Persons.AddAsync(actor);

            await _context.SaveChangesAsync();

            return Ok();
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
