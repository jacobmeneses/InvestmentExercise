using InvestmentExercise.Data;
using InvestmentExercise.Models;

namespace InvestmentExercise.Services
{
    public class UserService
    {
        private readonly InvestmentExerciseContext _context;
        public UserService(InvestmentExerciseContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
