using System.ComponentModel.DataAnnotations;

namespace InvestmentExercise.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public float Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
