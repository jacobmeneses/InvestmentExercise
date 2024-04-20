using Microsoft.EntityFrameworkCore;
using InvestmentExercise.Models;


namespace InvestmentExercise.Data
{
    public class InvestmentExerciseContext : DbContext
    {
        public InvestmentExerciseContext(DbContextOptions<InvestmentExerciseContext> options) : base(options) { }

        public DbSet<Investment> Investments => Set<Investment>();
        public DbSet<Oportunity> Oportunities => Set<Oportunity>();
        public DbSet<User> Users => Set<User>();
    }
}
