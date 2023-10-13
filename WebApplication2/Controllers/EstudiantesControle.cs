using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudiantesControle : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EstudiantesControle> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public EstudiantesControle(
            ILogger<EstudiantesControle> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.estudiante.Add(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]

        public IEnumerable<Estudiante> Get()
        {
            return _aplicacionContexto.estudiante.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.estudiante.Update(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int estudianteID)
        {
            _aplicacionContexto.estudiante.Remove(
                _aplicacionContexto.estudiante.ToList()
                .Where(x=>x.idestudainte == estudianteID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(estudianteID);
        }
    }
}