using InvestmentExercise.Data;
using InvestmentExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentExercise.Services
{
    public class OportunityService
    {
        private readonly InvestmentExerciseContext _context;
        public OportunityService(InvestmentExerciseContext context)
        {
            _context = context;
        }

        public IEnumerable<Oportunity> GetAll()
        {
            return _context.Oportunities
                .Include(o => o.Company)
                .AsNoTracking()
                .ToList();
        }
    }
}
