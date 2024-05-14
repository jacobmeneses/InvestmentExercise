using System.ComponentModel.DataAnnotations;

namespace InvestmentExercise.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
