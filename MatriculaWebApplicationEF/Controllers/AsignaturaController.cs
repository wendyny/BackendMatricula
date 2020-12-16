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
    public class AsignaturaController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly AsignaturaAppService _asignaturaAppService;

        public AsignaturaController(UniversidadDataContext context, AsignaturaAppService asignaturaAppService)
        {
            _baseDatos = context;
            _asignaturaAppService = asignaturaAppService;

            if (_baseDatos.Asignaturas.Count() == 0)
            {
                _baseDatos.Asignaturas.Add(new Asignatura { Nombre = "Matematicas", CursoId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        // GET: api/Asignatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignatura>>> GetAsignaturas()
        {
            return await _baseDatos.Asignaturas.Include(q => q.Curso).Include(q => q.DocentesPorAsignatura).ToListAsync();
        }

        // GET: api/Asignatura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> GetAsignatura(int id)
        {
            var asignatura = await _baseDatos.Asignaturas.Include(q => q.Curso).Include(q => q.DocentesPorAsignatura).FirstOrDefaultAsync(q => q.Id == id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return asignatura;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignatura(int id, Asignatura asignatura)
        {
            if (id != asignatura.Id)
            {
                return BadRequest();
            }

          
            Curso curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.Id == asignatura.CursoId);
            if (curso == null)
            {
                return NotFound("El curso no existe");
            }

            _baseDatos.Entry(asignatura).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

   
    [HttpPost]
        public async Task<ActionResult<Asignatura>> PostAsignatura(Asignatura asignatura)
        {
            var respuesta = await _asignaturaAppService.RegistrarAsignatura(asignatura);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetAsignatura), new { id = asignatura.Id }, asignatura);
        }
        // POST Rango: api/Asignatura
        [HttpPost("rango")]
        public async Task<ActionResult<Asignatura>> PostAsignatura(IEnumerable<Asignatura> asignaturas)
        {
            _baseDatos.Asignaturas.AddRange(asignaturas);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsignaturas),asignaturas);
        }
        // DELETE: api/Asignatura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignatura>> DeleteAsignatura(int id)
        {
            var asignatura = await _baseDatos.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            _baseDatos.Asignaturas.Remove(asignatura);
            await _baseDatos.SaveChangesAsync();

            return asignatura;
        }
        // DELETE Range: api/Asignatura/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteAsignatura(IEnumerable<int> ids)
        {
            IEnumerable<Asignatura> asignaturas = _baseDatos.Asignaturas.Where(q => ids.Contains(q.Id));

            if (asignaturas == null)
            {
                return NotFound();
            }

            _baseDatos.Asignaturas.RemoveRange(asignaturas);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
        private bool AsignaturaExists(int id)
        {
            return _baseDatos.Asignaturas.Any(e => e.Id == id);
        }
    }
}
