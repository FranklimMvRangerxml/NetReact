using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carritonet.Data;
using carritonet.Models;

namespace carritonet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SedeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sede
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sedes = await _context.Sedes.ToListAsync(); // ✅ Sedes no Sede
            return Ok(sedes); // ✅ faltaba punto y coma arriba
        }

        // GET: api/sede/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
                return NotFound("Sede no encontrada");
            return Ok(sede);
        }

        // POST: api/sede
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sede sede)
        {
            // ✅ UsuarioSede es int, no string
            if (sede.UsuarioSede == 0)
                return BadRequest("El usuario es requerido");

            // ✅ Propiedades con mayúscula (PascalCase en C#)
            if (string.IsNullOrEmpty(sede.Img))
                return BadRequest("La imagen es requerida");

            if (string.IsNullOrEmpty(sede.Nombre))
                return BadRequest("El nombre es requerido");

            if (string.IsNullOrEmpty(sede.Ubicacion))
                return BadRequest("La ubicación es requerida");

            sede.Fecha = DateTime.UtcNow; // ✅ UTC para PostgreSQL
            
            _context.Sedes.Add(sede); // ✅ Sedes no Sede
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sede.Id }, sede); // ✅ punto y coma
        }

        // PUT: api/sede/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Sede sede)
        {
            if (id != sede.Id)
                return BadRequest("El ID no coincide");

            _context.Entry(sede).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/sede/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
                return NotFound("Sede no encontrada");

            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}