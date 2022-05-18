using BLL.DTO;
using BLL.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase // контроллер для записей в карту
    {
        private readonly UserManager<DAL.Entity.User> _userManager;
        private readonly SignInManager<DAL.Entity.User> _signInManager;
        DBOperations db = new DBOperations();
        public RecordController(UserManager<DAL.Entity.User> userManager,
        SignInManager<DAL.Entity.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<List<RecordInPatientFileDTO>> GetAllAsync() // получение всех карт текущего пациента
        {
            if (!ModelState.IsValid)
            {
                return new List<RecordInPatientFileDTO>();
            }
            DAL.Entity.User user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new List<RecordInPatientFileDTO>();
            }
            var patient = db.GetPatients().Where(i => i.Email == user.Email).FirstOrDefault();
            if (patient == null)
            {
                return new List<RecordInPatientFileDTO>();
            }
            var result = Record.Get(patient.Id);
            return result;
        }
        private Task<DAL.Entity.User> GetCurrentUserAsync() =>
        _userManager.GetUserAsync(HttpContext.User);
    }
}
