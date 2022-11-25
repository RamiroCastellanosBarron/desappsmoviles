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
        public async Task<ActionResult<IEnumerable<Person>>> GetActors()
        {
            var actors = await _context.Persons
                .ToListAsync();

            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetActor(int id)
        {
            var actor = await _context.Persons
                .SingleOrDefaultAsync(x => x.Id == id);

            return Ok(actor);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<JsonResp>> DeleteActor(int id)
        {
            var actor = await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);

            _context.Persons.Remove(actor);

            await _context.SaveChangesAsync();

            return Ok(new JsonResp { Code = "OK"});
        }

        [HttpGet("update")]
        public async Task<ActionResult<JsonResp>> UpdateActor([FromQuery]ActorDto actorDto)
        {
            var actor = await _context.Persons.SingleOrDefaultAsync(x => x.Id == actorDto.Id);

            actor.Name = actorDto.Name;
            actor.PhotoUrl= actorDto.PhotoUrl;

            await _context.SaveChangesAsync();

            return Ok(new JsonResp { Code = "OK"});
        }

        [HttpGet("insert")]
        public async Task<ActionResult<JsonResp>> InsertActor([FromQuery]ActorDto actorDto)
        {
            var actor = new Person() { Name=actorDto.Name, PhotoUrl=actorDto.PhotoUrl };

            await _context.Persons.AddAsync(actor);

            await _context.SaveChangesAsync();

            return Ok(new JsonResp { Code ="OK"});
        }
    }

    public class JsonResp
    {
        public string Code { get; set; }
    }
}
