using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeeController : ControllerBase // контроллер записей на прием
    {
        ILogger logger;
        private readonly UserManager<DAL.Entity.User> _userManager;
        private readonly SignInManager<DAL.Entity.User> _signInManager;
        DBOperations db = new DBOperations();
        public SeeController(UserManager<DAL.Entity.User> userManager,
        SignInManager<DAL.Entity.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            logger = loggerFactory.CreateLogger<SeeController>();
        }
        [Authorize(Roles = "doctor")]
        [HttpGet]
        public async Task<List<DoctorSeeDTO>> GetAllAsync() // получение списка записей к текущему доктору
        {
            if (!ModelState.IsValid)
            {
                return new List<DoctorSeeDTO>();
            }
            DAL.Entity.User user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new List<DoctorSeeDTO>();
            }
            var doctor = db.GetDoctors().Where(i => i.Email == user.Email).FirstOrDefault();
            if (doctor == null)
            {
                return new List<DoctorSeeDTO>();
            }
            return db.GetDoctorSees().Where(i => i.DoctorId == doctor.Id
            && !i.Closed && i.Visited == null).ToList();
        }
        [Authorize(Roles = "doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) // закрытие записи
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var see = db.GetDoctorSee(id);
            if (see == null)
            {
                return BadRequest();
            }
            see.Closed = true;
            see.Visited = false;
            logger.LogInformation("Пациент не явился на прием " + see.Id);
            db.UpdateDoctorSee(see);
            return NoContent();
        }
        [Authorize(Roles = "doctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] RecordInPatientFileDTO
            record, [FromRoute] int id) // сохранение результатов приема
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Добавлена запись в карту " + record.Id);
            SeesOperations op = new SeesOperations();
            op.Post(record, id);
            return Ok();
        }
        private Task<DAL.Entity.User> GetCurrentUserAsync() =>
        _userManager.GetUserAsync(HttpContext.User);
    }
}
