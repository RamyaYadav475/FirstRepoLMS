namespace LoanManagementSystem.API.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public required string BorrowerName { get; set; }
        public decimal Amount { get; set; }
        public float InterestRate { get; set; }
        public int TermInMonths { get; set; }
    }
}
