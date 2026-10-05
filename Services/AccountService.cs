using ATMManagementSystem.API.Interfaces;
using ATMManagementSystem.API.Data;
using ATMManagementSystem.API.Models;
using ATMManagementSystem.API.DTO;
using Microsoft.EntityFrameworkCore;
namespace ATMManagementSystem.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _accountContext ;

        public AccountService(ApplicationDbContext accountContext)
        {
            _accountContext= accountContext;
        }
        public async Task<AccountDetailDTO> GetAccountDetailAsync(int accountId)
        {
            return await _accountContext.Account
            .Where(a=> a.AccountId== accountId)
            .Select(a => new AccountDetailDTO
            {
                AccountId= a.AccountId,
                AccountNumber= a.AccountNumber,
                FullName= a.User.FullName,
                Balance=a.Balance,
                IsActive=a.IsActive
            })
            .FirstOrDefaultAsync();
        }

        public async Task<decimal> DepositAsync(int accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            var account = await _accountContext.Account
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            decimal newBalance = account.Balance + amount;
            account.Balance = newBalance;

            var transaction = new TransactionModel
            {
                AccountId = accountId,
                TransactionType = "Deposit",
                Amount = amount,
                BalanceAfterTransaction = newBalance,
                TransactionDate = DateTime.UtcNow,
                Description = "Cash deposit"
            };

            _accountContext.Transaction.Add(transaction);

            await _accountContext.SaveChangesAsync();

            return newBalance;
        }

        public async Task<decimal> WithDrawAsync(int accountId, decimal amount)
        {
             if (amount <= 0)
            {
                throw new ArgumentException("Depowithdrawl  amount must be greater than zero.");
            }

            var account = await _accountContext.Account
            .FirstOrDefaultAsync(a => a.AccountId == accountId);
            
            //  if(amount>account.Balance)
            // {
            //     return NotFound();
            // }
            var newBalance= account.Balance - amount;
            account.Balance= newBalance;

              var transaction = new TransactionModel
            {
                AccountId = accountId,
                TransactionType = "Withdrawal",
                Amount = amount,
                BalanceAfterTransaction = newBalance,
                TransactionDate = DateTime.UtcNow,
                Description = "Cash Withdrawl"
            };
            _accountContext.Transaction.Add(transaction);
            await _accountContext.SaveChangesAsync();
            return newBalance;
        }
    }
}