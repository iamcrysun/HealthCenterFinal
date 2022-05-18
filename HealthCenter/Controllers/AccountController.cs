using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller // контроллер аккаунтов
    {
        private readonly UserManager<DAL.Entity.User> _userManager;
        private readonly SignInManager<DAL.Entity.User> _signInManager;
        ILogger logger; // логгер
        DBOperations db = new DBOperations();

        public AccountController(UserManager<DAL.Entity.User> userManager,
        SignInManager<DAL.Entity.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            db = new DBOperations();
            logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [Route("api/Account/Register")]
        // регистрация пользователя
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                DAL.Entity.User user = new DAL.Entity.User
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user,
                model.Password);
                // проверка роли на корректность
                if (model.Role != "admin" && model.Role != "user" && model.Role != "doctor")
                {
                    return BadRequest();
                }

                if (result.Succeeded)
                {
                    // установка роли
                    await _userManager.AddToRoleAsync(user, model.Role);
                    
                    if (model.Role == "doctor")
                    {
                        // добавление почты к аккаунту доктора
                        var doctor = db.GetDoctor(model.Id);
                        if (doctor != null)
                        {
                            doctor.Email = model.Email;
                            IdentityOperations identity = new IdentityOperations();
                            identity.setDoctor(doctor);
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }

                    if (model.Role == "user")
                    {
                        // добавление почты к аккаунту пациента
                        var patient = db.GetPatient(model.Id);
                        if (patient != null)
                        {
                            patient.Email = model.Email;
                            IdentityOperations identity = new IdentityOperations();
                            identity.setPatient(patient);
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }

                    var msg = new
                    {
                        message = "Добавлен новый пользователь: " +
                    user.UserName
                    };
                    logger.LogInformation("Добавлен новый пользователь: " +
                    user.UserName);
                    return Ok(msg);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,
                        error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен.",
                        error = ModelState.Values.SelectMany(e =>
                        e.Errors.Select(er => er.ErrorMessage))
                    };
                    logger.LogError(errorMsg.ToString());
                    return StatusCode(203, errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные.",
                    error = ModelState.Values.SelectMany(e =>
                    e.Errors.Select(er => er.ErrorMessage))
                };
                logger.LogError(errorMsg.ToString());
                return StatusCode(203, errorMsg);
            }
        }

        [HttpPost]
        [Route("api/Account/Login")]
        // вход пользователя
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,
                true /*запомнить true, т.к. вход проверяется при обращении к методам*/, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    string role = "user";
                    if (await _userManager.IsInRoleAsync(user, "admin"))
                    {
                        role = "admin";
                        logger.LogInformation("Вход администратора " + model.Email);
                    }
                    if (await _userManager.IsInRoleAsync(user, "doctor"))
                    {
                        role = "doctor";
                        logger.LogInformation("Вход доктора " + model.Email);
                    }
                    var msg = new
                    {
                        messange = "Выполнен вход пользователем: " + model.Email,
                        role = role
                    };
                    return Ok(msg);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен.",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    logger.LogError(errorMsg.ToString());
                    return StatusCode(203, errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен.",
                    error = ModelState.Values.SelectMany(e =>
                    e.Errors.Select(er => er.ErrorMessage))
                };
                logger.LogError(errorMsg.ToString());
                return StatusCode(203, errorMsg);
            }
        }
        [HttpPost]
        [Route("api/Account/LogOff")]
        // выход из аккаунта
        public async Task<IActionResult> LogOff()
        {
            // Удаление куки
            await _signInManager.SignOutAsync();
            var msg = new
            {
                message = "Выполнен выход."
            };
            return Ok(msg);
        }

        [HttpPost]
        [Route("api/Account/checkRole/")]
        // проверка роли текущего пользователя
        public async Task<IActionResult> CheckRole()
        {
            DAL.Entity.User user = await GetCurrentUserAsync();
            string role;
            if (user == null)
            {
                role = "";
            }
            else
            {
                if (await _userManager.IsInRoleAsync(user, "admin"))
                {
                    role = "admin";
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, "doctor"))
                    {
                        role = "doctor";
                    }
                    else
                    {
                        role = "user";
                    }
                        
                }
            }
            var msg = new
            {
                role = role
            };
            return Ok(msg);
        }

        // получение текущего пользователя
        private Task<DAL.Entity.User> GetCurrentUserAsync() =>
        _userManager.GetUserAsync(HttpContext.User);
    }
}
