namespace Domain.Account;

public interface IAccountRepository
{
    Task<string?> QueryAccount(string accountId);

    Task<string?> QueryRole(string id);

    Task<string?> QueryLine(string id);
}
