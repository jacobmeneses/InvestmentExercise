namespace InvestmentExercise.Models
{
    public class Oportunity
    {
        public int ID { get; set; }
        public float Total { get; set; }
        public float Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Investment> Investments { get; set; }
    }
}
