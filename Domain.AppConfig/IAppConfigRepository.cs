namespace Domain.AppConfigure;

public interface IAppConfigRepository
{
    Task<AppConfigure> AppConfigure();
}
