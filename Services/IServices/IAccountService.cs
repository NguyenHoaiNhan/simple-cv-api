using SimpleCV.Data.DTO.Account;

namespace SimpleCV.Services.IServices
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccount(int accountId, string pwd);
        Task<AccountDTO> AddAccount(AccountDTO account);
        Task UpdateAccount(AccountDTO account);
    }
}