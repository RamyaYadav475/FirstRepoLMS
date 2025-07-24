using LoanManagementSystem.API.Data;
using LoanManagementSystem.API.Models;

namespace LoanManagementSystem.API.Services
{
    // public class LoanService : ILoanService
    // {
    //     private static List<Loan> loans = new List<Loan>
    //     {
    //         new Loan { Id = 1, BorrowerName = "Alice", Amount = 50000, InterestRate = 7.5f, TermInMonths = 36 },
    //         new Loan { Id = 2, BorrowerName = "Bob", Amount = 100000, InterestRate = 6.5f, TermInMonths = 60 }
    //     };

    //     public List<Loan> GetAll() => loans;

    //     public Loan? GetById(int id) => loans.FirstOrDefault(l => l.Id == id);

    //     public Loan Create(Loan loan)
    //     {
    //         loan.Id = loans.Max(l => l.Id) + 1;
    //         loans.Add(loan);
    //         return loan;
    //     }

    //      public Loan Update(int id, Loan loan)
    //     {
    //         var existing = GetById(id);
    //         if (existing == null) return null;

    //         existing.BorrowerName = loan.BorrowerName;
    //         existing.Amount = loan.Amount;
    //         existing.InterestRate = loan.InterestRate;
    //         existing.TermInMonths = loan.TermInMonths;
    //         return existing;
    //     }

    //     public bool Delete(int id)
    //     {
    //         var loan = GetById(id);
    //         if (loan == null) return false;
    //         loans.Remove(loan);
    //         return true;
    //     }
    // }

    public class LoanService : ILoanService
    {
        private readonly LoanDbContext _context;

        public LoanService(LoanDbContext context)
        {
            _context = context;
        }

        public List<Loan> GetAll() => _context.Loans.ToList();

        public Loan? GetById(int id) => _context.Loans.Find(id);

        public Loan Create(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public Loan? Update(int id, Loan updated)
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            var existing = _context.Loans.Find(id);
            if (existing == null) return null;

            existing.BorrowerName = updated.BorrowerName;
            existing.Amount = updated.Amount;
            existing.InterestRate = updated.InterestRate;
            existing.TermInMonths = updated.TermInMonths;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan == null) return false;

            _context.Loans.Remove(loan);
            _context.SaveChanges();
            return true;
        }
    }

}
