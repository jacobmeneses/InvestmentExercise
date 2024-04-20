namespace InvestmentExercise.Models
{
    public class Investment
    {
        public int ID { get; set; }
        public float Total { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public Oportunity Oportunity { get; set; }
    }
}
