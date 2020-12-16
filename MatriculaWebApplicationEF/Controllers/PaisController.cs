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
    public class PaisController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly PaisAppService _paisAppService;


        public PaisController(UniversidadDataContext baseDeDatos, PaisAppService paisAppService)
        {
            _baseDatos = baseDeDatos;
            _paisAppService = paisAppService;
            if (_baseDatos.Paises.Count() == 0)
            {
                _baseDatos.Paises.Add(new Pais { Nombre = "Honduras" });
                _baseDatos.SaveChanges();
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return await _baseDatos.Paises.Include(e => e.EstudiantesPorPais).ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais = await _baseDatos.Paises.Include(q => q.EstudiantesPorPais).FirstOrDefaultAsync(q => q.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            _baseDatos.Entry(pais).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();


            return Ok("sucess");
        }

        
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            var respuesta = await _paisAppService.RegistrarPais(pais);

            if (respuesta != null)
            {
                return BadRequest(respuesta);
            }

            return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);

        }

        [HttpPost("rango")]
        public async Task<ActionResult<Pais>> PostPais(IEnumerable<Pais> paises)
        {
            _baseDatos.Paises.AddRange(paises);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaises), paises);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> DeletePais(int id)
        {
            var pais = await _baseDatos.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _baseDatos.Paises.Remove(pais);
            await _baseDatos.SaveChangesAsync();

            return pais;
        }

        private bool PaisExists(int id)
        {
            return _baseDatos.Paises.Any(e => e.Id == id);
        }
    }
}
