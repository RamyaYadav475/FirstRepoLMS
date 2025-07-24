// namespace LoanManagementSystem.API.DTOs
// {
//     public class LoanCreateDto
//     {
//         public string BorrowerName { get; set; }
//         public decimal Amount { get; set; }
//         public float InterestRate { get; set; }
//         public int TermInMonths { get; set; }
//     }
// }
using System.ComponentModel.DataAnnotations;
namespace LoanManagementSystem.API.DTOs
{
    public class LoanCreateDto
    {
        [Required]
        [StringLength(50)]
        public required string BorrowerName { get; set; }
        [Range(1, 10000000)]
        public decimal Amount { get; set; }
        [Range(1, 50)]
        public float InterestRate { get; set; }
        [Range(1, 360)]
        public int TermInMonths { get; set; }
    }
}
