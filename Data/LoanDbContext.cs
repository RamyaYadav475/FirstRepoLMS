using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.API.Models;

namespace LoanManagementSystem.API.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }

        public DbSet<Loan> Loans { get; set; }  // this is a table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasPrecision(18, 2); // 18 total digits, 2 after decimal
        }

    }
}
