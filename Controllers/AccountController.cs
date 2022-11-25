using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimpleCV.Data.DTO.Account;
using SimpleCV.Services.IServices;

namespace SimpleCV.Controllers
{
    [Route("API/Account/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [ActionName("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(int accountId, string pwd)
        {
            try
            {
                var result = await _accountService.GetAccount(accountId, pwd);

                if (result != null)
                    return Ok(result);

                return BadRequest("Account or Password is not correct");
            }
            catch (Exception)
            {
                return BadRequest("Get account failed");
            }
        }

        [ActionName("AddAccount")]
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountDTO account)
        {
            try
            {
                return Ok(await _accountService.AddAccount(account));
            }
            catch (Exception)
            {
                return BadRequest("Add account failed");
            }
        }

        [ActionName("UpdateAccount")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAccount(int accountId, string pwd, JsonPatchDocument<AccountDTO> account)
        {
            try
            {
                var accountToUpdate = await _accountService.GetAccount(accountId, pwd);
                account.ApplyTo(accountToUpdate);
                await _accountService.UpdateAccount(accountToUpdate);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Update account failed");
            }
        }
    }
}