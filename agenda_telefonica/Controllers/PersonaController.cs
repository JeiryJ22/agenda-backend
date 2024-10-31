using agenda_telefonica.Entities;
using agenda_telefonica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_telefonica.Controllers
{
    [Route ("agenda/personas")]
    public class PersonaController: ControllerBase
    {
        private readonly AppDbContext context;

        public PersonaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<List<Persona>> Get()
        {
            return await context.Personas.ToListAsync();    
        }
        [HttpGet("{id:int}", Name = "GetPersonById")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.IdPersona == id);
            if (persona is null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post(Persona persona)
        {
            context.Add(persona);//Se guarda en memoria
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetPersonById", new {id = persona.IdPersona}, persona);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Persona persona)
        {
            var exist = await context.Personas.AnyAsync(p => p.IdPersona == id);
            if (!exist)
            {
                return NotFound();
            }
            context.Update(persona);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPerson = await context.Personas.Where(p => p.IdPersona == id).ExecuteDeleteAsync();
            if (deletedPerson == 0)
            {
                return NotFound(); 
            }
            return NoContent();
        }
    }
}
