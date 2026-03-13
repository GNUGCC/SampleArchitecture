namespace Domain.Account;

public interface IAccountRepository
{
    Task<AccountConfigure> LoadAccountConfigure();

    Task<string?> QueryAccount(string accountId);
}
