using ATMManagementSystem.API.Services;
using ATMManagementSystem.API.DTO;
namespace ATMManagementSystem.API.Interfaces
{
    public interface IAccountService
    {
       Task<AccountDetailDTO> GetAccountDetailAsync(int accountId);
        Task<decimal> DepositAsync(int accountId, decimal amount);
        Task<decimal> WithDrawAsync(int accountId, decimal amount);
       


    }
}