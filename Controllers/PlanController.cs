using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carritonet.Data;
using carritonet.Models;

namespace carritonet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/plan
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planes = await _context.Planes.ToListAsync(); // ✅ Planes no Plan
            return Ok(planes); // ✅ faltaba punto y coma
        }

        // GET: api/plan/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plan = await _context.Planes.FindAsync(id);
            if (plan == null)
                return NotFound("Plan no encontrado");
            return Ok(plan);
        }

        // POST: api/plan
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Plan plan)
        {
            // ✅ plan no sede
            if (string.IsNullOrEmpty(plan.Nombre))
                return BadRequest("El nombre es requerido");

            // ✅ MaxDays es int no string
            if (plan.MaxDays == 0)
                return BadRequest("Los días máximos son requeridos");

            plan.Fecha = DateTime.UtcNow;

            _context.Planes.Add(plan); // ✅ Planes no Plans, punto y coma
            await _context.SaveChangesAsync(); // ✅ faltaba esto

            return CreatedAtAction(nameof(GetById), new { id = plan.Id }, plan);
        }

        // PUT: api/plan/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Plan plan)
        {
            if (id != plan.Id)
                return BadRequest("El ID no coincide");

            _context.Entry(plan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/plan/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _context.Planes.FindAsync(id);
            if (plan == null)
                return NotFound("Plan no encontrado");

            _context.Planes.Remove(plan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}