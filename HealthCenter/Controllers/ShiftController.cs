using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase // контроллер смен
    {
        DBOperations db = new DBOperations();
        [HttpGet]
        public List<ShiftDTO> GetAll() // получение списка смен
        {
            if (!ModelState.IsValid)
            {
                return new List<ShiftDTO>();
            }
            return db.GetShifts();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // получение смены
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shift = db.GetShift(id)
    ;
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }
    }
}