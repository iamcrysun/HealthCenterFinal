using BLL.DTO;
using BLL.Operations;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/Doctor")]
[ApiController]

public class DoctorController : Controller // контроллер докторов
{
    DBOperations db = new DBOperations();
    [HttpGet]
    public List<DoctorDTO> GetAll() // получение справочника докторов
    {
        if (!ModelState.IsValid)
        {
            return new List<DoctorDTO>();
        }
        return db.GetDoctors();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id) // получение доктора
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var doctor = db.GetDoctor(id)
;
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
}
