using Microsoft.EntityFrameworkCore;
using ATMManagementSystem.API.Models;


namespace ATMManagementSystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}
        public DbSet<UserModel> User {get;set;}
        public DbSet<AccountModel> Account{get;set;}
        public DbSet<TransactionModel> Transaction{get;set;}




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountModel>().Property(a => a.Balance).HasPrecision(18, 2);
        modelBuilder.Entity<TransactionModel>().Property(t => t.Amount).HasPrecision(18, 2);
        modelBuilder.Entity<TransactionModel>().Property(t => t.BalanceAfterTransaction).HasPrecision(18, 2);
        modelBuilder.Entity<UserModel>().HasMany(u => u.Account).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        modelBuilder.Entity<AccountModel>().HasMany(a => a.Transaction).WithOne(t => t.Account).HasForeignKey(t => t.AccountId);
        modelBuilder.Entity<AccountModel>().HasIndex(a => a.AccountNumber).IsUnique();
    }
    }
}