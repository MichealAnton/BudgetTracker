using Budget_Tracker.Models;
using Microsoft.EntityFrameworkCore;
namespace Budget_Tracker.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        { }
        public DbSet<User> Usres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
