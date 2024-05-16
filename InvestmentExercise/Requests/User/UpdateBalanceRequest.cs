
namespace InvestmentExercise.Requests
{
    public class UpdateBalanceRequest {
        public int UserId { get; set; }
        public string Action { get; set; }
        public float Amount { get; set; }
    }

}