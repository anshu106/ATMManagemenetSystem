using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ATMManagementSystem.API.Interfaces;
using ATMManagementSystem.API.DTO;
namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _context;

        public AccountController(IAccountService context)
        {
            _context= context;
        }

        [HttpGet("/detail/{id}")]
        public async Task<IActionResult> GetDetailAccount(int id)
        {
            var account = await _context.GetAccountDetailAsync(id);
              if (account == null)
        {
            return NotFound(new
            {
                message = "Account not found."
            });
        }
            return Ok(account);
        }

        [HttpPost("/deposit")]
        public async Task<IActionResult> DepositAmountDetail(DepositDTO deposit)
        {
            await _context.DepositAsync(
                deposit.AccountId,
                deposit.Amount
            );
            return Ok(new {message="Amount Deposited successfully"});
        }

        [HttpPost("/withdraw")]
        public async Task<IActionResult> WithDrawDetail([FromBody] WithdrawDTO withdraw)
        {
            await _context.WithDrawAsync(
                withdraw.AccountId,
                withdraw.Amount
            );
            return Ok(new {message="Amount withdrawl successfully"});
        }
    }
}
