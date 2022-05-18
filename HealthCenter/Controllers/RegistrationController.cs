using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase // контроллер для записи на прием
    {
        private readonly UserManager<DAL.Entity.User> _userManager;
        private readonly SignInManager<DAL.Entity.User> _signInManager;
        ILogger logger;
        DBOperations db = new DBOperations();
        RegistrationsOperations rg = new RegistrationsOperations();
        public RegistrationController(UserManager<DAL.Entity.User> userManager,
        SignInManager<DAL.Entity.User> signInManager)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            logger = loggerFactory.CreateLogger<RegistrationController>();
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "user")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Doctor([FromRoute] int id) // получение доктора с переданной
                                                                    // специальностью для текущего пользователя
        {
            DAL.Entity.User user = await GetCurrentUserAsync();
            if (user == null)
            {
                return StatusCode(401);
            }
            var msg = new
            {
                // получение доктора
                doctor = rg.GetDoctor(id, user.Email),
                // получение дней, когда доктор осуществляет прием
                days = rg.GetDays(id, user.Email)
            };
            return Ok(msg);
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> Times([FromBody] TimesDTO times) // получение списка доступных
                                                                          // времен записи на переданную дату
        {
            var msg = new
            {
                times = rg.GetTimes(times.ID, times.date)
            };
            return Ok(msg);
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> Write([FromBody] DoctorSeeDTO see) // запись на прием
        {
            DAL.Entity.User user = await GetCurrentUserAsync();
            if (user == null)
            {
                return StatusCode(401);
            }
            see.PatientId = db.GetPatients().Where(i => i.Email == user.Email).First().Id;
            if (see.DateTime > DateTime.Now)
            {
                see.Id = db.AddDoctorSee(see);
                if (see.Id > -1)
                {
                    Email.Reg(see, user.Email); // отправка талона на почту
                    logger.LogInformation("Выполнена запись талона номер " + see.Id);
                    return Ok("Запись выполнена. Талон отправлен на почту");
                }
                return BadRequest();
            }
            return Ok("Дата уже прошла");
        }
        private Task<DAL.Entity.User> GetCurrentUserAsync() =>
        _userManager.GetUserAsync(HttpContext.User);
    }
}
