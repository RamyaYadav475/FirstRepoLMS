using LoanManagementSystem.API.Models;

namespace LoanManagementSystem.API.Services
{
    public interface ILoanService
    {
        List<Loan> GetAll();
        Loan? GetById(int id);
        Loan Create(Loan loan);
        Loan Update(int id, Loan loan);
        bool Delete(int id);
    }
}

