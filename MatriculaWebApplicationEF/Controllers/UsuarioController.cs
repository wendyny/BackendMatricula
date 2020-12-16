using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.Models;
using MatriculaWebApplicationEF.ApplicationServices;

namespace MatriculaWebApplicationEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly UsuarioAppService _usuarioAppService;

        public UsuarioController(UniversidadDataContext baseDeDatos, UsuarioAppService usuarioAppService)
        {
            _baseDatos = baseDeDatos;
            _usuarioAppService = usuarioAppService;
            if (_baseDatos.Usuarios.Count() == 0)
            {
                _baseDatos.Usuarios.Add(new Usuario { NombreUsuario = "Wendy", passwordUsuario="1234",isActive=false });
                _baseDatos.SaveChanges();
            }
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _baseDatos.Usuarios.ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _baseDatos.Entry(usuario).State = EntityState.Modified;

            
                await _baseDatos.SaveChangesAsync();
            return Ok("sucess");
        }

         
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var respuesta = await _usuarioAppService.RegistrarUsuario(usuario);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPost("rango")]
        public async Task<ActionResult<Usuario>> PostUsuario(IEnumerable<Usuario> usuarios)
        {
            _baseDatos.Usuarios.AddRange(usuarios);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _baseDatos.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _baseDatos.Usuarios.Remove(usuario);
            await _baseDatos.SaveChangesAsync();

            return Ok("sucess");

        }
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteUsuarios(IEnumerable<int> ids)
        {
            IEnumerable<Usuario> usuarios = _baseDatos.Usuarios.Where(q => ids.Contains(q.Id));

            if (usuarios == null)
            {
                return NotFound();
            }

            _baseDatos.Usuarios.RemoveRange(usuarios);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
        private bool UsuarioExists(int id)
        {
            return _baseDatos.Usuarios.Any(e => e.Id == id);
        }
    }
}
