using Domain.Account;

namespace Infranstracture.Test;

public readonly struct TestAccountRepository : IAccountRepository
{
    Task<AccountConfigure> IAccountRepository.LoadAccountConfigure()
    {
        throw new NotImplementedException();
    }

    Task<string?> IAccountRepository.QueryAccount(string accountId)
    {
        throw new NotImplementedException();
    }
}
