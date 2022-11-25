using AutoMapper;
using SimpleCV.Data.DTO.Account;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;
using SimpleCV.Services.IServices;

namespace SimpleCV.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        
        public async Task<AccountDTO> GetAccount(int accountId, string pwd)
        {
            var properAccount = await _accountRepository.Get(
                x => x.AccountId == accountId
                && x.AccountPwd == pwd
            );
            
            if(properAccount == null)
                return null;
            
            return _mapper.Map<AccountDTO>(properAccount);
        }

        public async Task<AccountDTO> AddAccount(AccountDTO account)
        {
            return _mapper.Map<AccountDTO>(
                await _accountRepository.Add(_mapper.Map<Account>(account))
            );
        }

        public async Task UpdateAccount(AccountDTO account)
        {
            await _accountRepository.Update(_mapper.Map<Account>(account));
        }
    }
}