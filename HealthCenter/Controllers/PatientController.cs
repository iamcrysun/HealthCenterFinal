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
    public class PatientController : ControllerBase // контроллер пациентов
    {
        DBOperations db = new DBOperations();
        [HttpGet]
        public List<PatientDTO> GetAll() // получение справочника пациентов
        {
            if (!ModelState.IsValid)
            {
                return new List<PatientDTO>();
            }
            return db.GetPatients();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // получение пациента
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patient = db.GetPatient(id)
    ;
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
