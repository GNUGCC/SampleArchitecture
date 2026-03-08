namespace Domain.Account;

public interface IAccountRepository
{
    Task<AccountConfigure> LoadAccountConfigure();
}
