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
    public class CursoController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoAppService _cursoAppService;


        public CursoController(UniversidadDataContext baseDeDatos, CursoAppService cursoAppService)
        {
            _baseDatos = baseDeDatos;
            _cursoAppService = cursoAppService;
            if (_baseDatos.Cursos.Count() == 0)
            {
                _baseDatos.Cursos.Add(new Curso { Nombre = "Angular" });
                _baseDatos.SaveChanges();
            }
        }

        // GET: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _baseDatos.Cursos.Include(q => q.Estudiantes).Include(q => q.Asignaturas).ToListAsync();
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _baseDatos.Cursos.Include(q => q.Estudiantes).Include(q => q.Asignaturas).FirstOrDefaultAsync(q => q.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Curso/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            _baseDatos.Entry(curso).State = EntityState.Modified;

             await _baseDatos.SaveChangesAsync();
            return Ok("sucess");
            }

           
        // POST: api/Curso
     
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {

            var respuesta = await _cursoAppService.RegistrarCurso(curso);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
            
        }
        // POST Rango: api/Curso
        [HttpPost("rango")]
        public async Task<ActionResult<Curso>> PostCurso(IEnumerable<Curso> cursos)
        {
            _baseDatos.Cursos.AddRange(cursos);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCursos), cursos);
        }
        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curso>> DeleteCurso(int id)
        {
            var curso = await _baseDatos.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.Remove(curso);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }
        // DELETE Range: api/Cursos/5
        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCursos(IEnumerable<int> ids)
        {
            IEnumerable<Curso> cursos = _baseDatos.Cursos.Where(q => ids.Contains(q.Id));

            if (cursos == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.RemoveRange(cursos);
            await _baseDatos.SaveChangesAsync();

            return Ok("success");
        }


        private bool CursoExists(int id)
        {
            return _baseDatos.Cursos.Any(e => e.Id == id);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              