using FinanceTrackingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Saving> Savings { get; set; }
    }
}