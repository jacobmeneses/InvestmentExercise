using Microsoft.AspNetCore.Http;
using InvestmentExercise.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OportunityController : ControllerBase
    {
        OportunityService _service;

        public OportunityController(OportunityService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
