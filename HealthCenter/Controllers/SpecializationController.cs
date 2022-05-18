using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase // контроллер специализаций
    {
        DBOperations db = new DBOperations();
        [HttpGet]
        public List<SpecializationDTO> GetAll() // получение всех специализаций
        {
            if (!ModelState.IsValid)
            {
                return new List<SpecializationDTO>();
            }
            return db.GetSpecializations();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // получение специализации
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var spec = db.GetSpecialization(id);
            if (spec == null)
            {
                return NotFound();
            }
            return Ok(spec);
        }
    }
}
