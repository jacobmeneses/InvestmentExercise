using InvestmentExercise.Data;
using InvestmentExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentExercise.Services
{
    public class InvestmentService
    {
        private readonly InvestmentExerciseContext _context;
        public InvestmentService(InvestmentExerciseContext context)
        {
            _context = context;
        }

        // TODO: Refactor this function
        public void DoInvest(int oportunityId, Investment investment)
        {
            var oportunity = _context.Oportunities.Include(m => m.Investments).FirstOrDefault(m => m.ID == oportunityId);
            
            if (oportunity == null)
            {
                throw new InvalidOperationException("Oportunity does not exists");
            }

            var currentInvestments = oportunity.Investments;
            var totalInvested = 0.0f;

            if ( currentInvestments != null && currentInvestments.Count > 0)
            {
                totalInvested = currentInvestments.Select(i => i.Total).Aggregate((current, next) => current + next);
            }
            
            var newTotalInvested = totalInvested + investment.Total;
            var user = investment.User;

            if ( newTotalInvested - oportunity.Total >= 0.01 )
            {
                throw new InvalidOperationException("Investment exceeds max available");
            }

            if ( investment.Total - user.Balance >= 0.01 )
            {
                throw new InvalidOperationException("Not enough balance");
            }

            // TODO: concurrency
            investment.CreatedAt = DateTime.UtcNow;

            if ( currentInvestments  == null )
            {
                oportunity.Investments = new List<Investment>();
                currentInvestments = oportunity.Investments;
            }

            currentInvestments.Add(investment);
            user.Balance -= investment.Total;

            _context.SaveChanges();
        }
    }
}
