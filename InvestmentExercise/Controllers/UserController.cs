using Microsoft.AspNetCore.Http;
using InvestmentExercise.Services;
using Microsoft.AspNetCore.Mvc;
using InvestmentExercise.Requests;
using Microsoft.Extensions.Logging;

namespace InvestmentExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _service;
        ILogger<UserController> _logger;

        public UserController(UserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPut("balance")]
        public IActionResult UpdateBalance(UpdateBalanceRequest request)
        {
            _logger.LogInformation("hello: {something}", request.Amount);
            return Ok(_service.Get(0));
        }
    }
}
