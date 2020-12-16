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
    public class DocenteController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly DocenteAppService _docenteAppService;

        public DocenteController(UniversidadDataContext context, DocenteAppService docenteAppService)
        {
            _baseDatos = context;
            _docenteAppService = docenteAppService;
            if (_baseDatos.Docentes.Count() == 0)
            {
                _baseDatos.Docentes.Add(new Docente { Nombre = "Wendy", Edad = 27, Sexo = "F", AsignaturaId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docente>>> GetDocentes()
        {
            return await _baseDatos.Docentes.Include(p => p.Asignatura).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> GetDocente(int id)
        {
            var docente = await _baseDatos.Docentes.Include(p => p.Asignatura).FirstOrDefaultAsync(q => q.Id == id);

            if (docente == null)
            {
                return NotFound();
            }

            return docente;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente(int id, Docente docente)
        {
            if (id != docente.Id)
            {
                return BadRequest();
            }
            Asignatura asignatura = await _baseDatos.Asignaturas.FirstOrDefaultAsync(q => q.Id == docente.AsignaturaId);
            if (asignatura == null)
            {
                return NotFound("La asignatura no existe");
            }
            _baseDatos.Entry(docente).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }

       
        [HttpPost]
        public async Task<ActionResult<Docente>> PostDocente(Docente docente)
        {
            var respuesta = await _docenteAppService.RegistrarDocente(docente);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetDocente), new { id = docente.Id }, docente);
        }
        [HttpPost("rango")]
        public async Task<ActionResult<Docente>> PostDocente(IEnumerable<Docente> docentes)
        {
            _baseDatos.Docentes.AddRange(docentes);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocentes), docentes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Docente>> DeleteDocente(int id)
        {
            var docente = await _baseDatos.Docentes.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }

            _baseDatos.Docentes.Remove(docente);
            await _baseDatos.SaveChangesAsync();

            return docente;
        }
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteDocentes(IEnumerable<int> ids)
        {
            IEnumerable<Docente>docentes = _baseDatos.Docentes.Where(q => ids.Contains(q.Id));

            if (docentes == null)
            {
                return NotFound();
            }

            _baseDatos.Docentes.RemoveRange(docentes);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
        private bool DocenteExists(int id)
        {
            return _baseDatos.Docentes.Any(e => e.Id == id);
        }
    }
}
