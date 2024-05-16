using Microsoft.AspNetCore.Http;
using InvestmentExercise.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/[controller]/balance")]
        public IActionResult UpdateBalance()
        {
            return Ok(_service.Get(0));
        }
    }
}
