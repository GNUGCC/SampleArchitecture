namespace Domain.Account;

public readonly struct AccountConfigure(string username, string email, string rule, string principle, IAccountRepository? repository = default)
{
}