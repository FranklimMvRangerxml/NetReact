using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carritonet.Data;
using carritonet.Models;
//Forma de utilizacion
/* Siempre llama a las carpetas y dentro llama los archivos..
Ejempl:

models
controllers
Data
*/
namespace carritonet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Mostrar lista relacionada
            var usuarios = await _context.Usuarios
            .Include(u => u.Plan)
            .Include(u => u.Sede)
            .ToListAsync();
            
            return Ok(usuarios);
        }

        // GET: api/usuario/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            return Ok(usuario);
        }

     // POST Crear usuario: api/usuario
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] Usuario usuario)
            {
                // Validaciones básicas
                if (string.IsNullOrEmpty(usuario.Nombre))
                    return BadRequest("El nombre es requerido");

                if (string.IsNullOrEmpty(usuario.Correo))
                    return BadRequest("El correo es requerido");

                if (string.IsNullOrEmpty(usuario.ContrasenaHash))
                    return BadRequest("La contraseña es requerida");

                // Verificar que el correo no exista
                var existe = await _context.Usuarios
                    .AnyAsync(u => u.Correo == usuario.Correo);
                if (existe)
                    return BadRequest("El correo ya está registrado");

                // Hashear la contraseña antes de guardar
                usuario.ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(usuario.ContrasenaHash);
                usuario.CreadoEn = DateTime.Now;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
         

        // PUT: api/usuario/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("El ID no coincide");

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usuario/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }
}