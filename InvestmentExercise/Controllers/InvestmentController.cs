using InvestmentExercise.Models;
using InvestmentExercise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentExercise.Controllers
{
    public class CreateInvestmentRequest
    {
        public int OportunityId {  get; set; }
        public int UserId { get; set; }
        public float Amount { get; set; }

        public Investment ToInvestmentModel()
        {
            return new Investment
            {
                Total = this.Amount,
                User = new User
                {
                    ID = this.UserId,
                }
            };
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        InvestmentService _service;
        UserService _user_service;

        public InvestmentController(InvestmentService service, UserService user_service)
        {
            _service = service;
            _user_service = user_service;
        }

        [HttpPost]
        public IActionResult Create(CreateInvestmentRequest request)
        {
            var investment = request.ToInvestmentModel();

            investment.User = _user_service.Get(request.UserId);


            if ( investment.User == null )
            {
                return NotFound();
            }

            _service.DoInvest(request.OportunityId, investment);

            return CreatedAtAction(null, new { id = investment.ID }, investment);
        }
    }
}
