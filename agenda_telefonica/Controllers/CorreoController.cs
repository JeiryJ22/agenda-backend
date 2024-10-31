using agenda_telefonica.Entities;
using agenda_telefonica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agenda_telefonica.Controllers
{
    [Route("agenda/correos")]
    [ApiController]
    public class CorreoController: ControllerBase
    {
        private readonly AppDbContext context;

        public CorreoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Correo>>> Get()
        {
            return await context.Correos.ToListAsync(); 
        }
        [HttpGet("{id:int}", Name = "GetCorreoById")]
        public async Task<ActionResult<Correo>> Get(int id)
        {
            var correo = await context.Correos.FirstOrDefaultAsync(c => c.IdCorreo == id);
            if (correo == null)
            {
                return NotFound();
            }
            return correo;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Correo correo)
        {
            context.Correos.Add(correo);
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetCorreoById", new { id = correo.IdCorreo }, correo);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Correo correo)
        {
            if (id != correo.IdCorreo)
            {
                return BadRequest();
            }
            var exist = await context.Correos.AnyAsync(c => c.IdCorreo == id);
            if (!exist)
            {
                return NotFound();
            }
                context.Update(correo);
                await context.SaveChangesAsync();
                return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var correoQuantity = await context.Correos.CountAsync(c => c.IdPersona == id);
            if (correoQuantity <= 1)
            {
                return BadRequest("Casa contacto debe de tener al menos un correo");
            }
            var correo = await context.Correos.FindAsync(id);
            if (correo == null) 
            {
                return NotFound();
            }
            context.Correos.Remove(correo);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
