using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Authorization;
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
    public class ScheduleController : ControllerBase // контроллер для расписания
    {
        DBOperations db = new DBOperations();
        [HttpGet]
        public List<ScheduleDTO> GetAll() // получения всех строк расписания
        {
            if (!ModelState.IsValid)
            {
                return new List<ScheduleDTO>();
            }
            return db.GetSchedules();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) // получение расписания
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Schedule = db.GetSchedule(id)
;
            if (Schedule == null)
            {
                return NotFound();
            }
            return Ok(Schedule);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ScheduleDTO Schedule) // добавление новой строки в расписание
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.AddSchedule(Schedule);
            return CreatedAtAction("Get", new { id = Schedule.Id }, Schedule);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public  IActionResult Update([FromBody] ScheduleDTO Schedule) // обновление строки расписания
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ScheduleOperations scheduleOperations = new ScheduleOperations();
            scheduleOperations.Update(Schedule);

            return NoContent();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) // удаление строки расписания
        {
            ScheduleOperations scheduleOperations = new ScheduleOperations();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            scheduleOperations.Delete(db.GetSchedule(id));
            
            return NoContent();
        }
    }
}
