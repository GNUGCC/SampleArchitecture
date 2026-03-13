namespace Domain.AppConfigure;

public interface IAppConfigRepository
{
    Task<string?> LoadAppName();
}