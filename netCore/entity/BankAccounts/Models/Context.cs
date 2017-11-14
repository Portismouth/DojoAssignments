using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> AccountChanges { get; set; }
    }
}