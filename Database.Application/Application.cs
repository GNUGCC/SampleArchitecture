using Application.Interface;
using Application.Interface.Menu;
using Application.Impl.Application.Menu;
using Domain.Menu;

namespace Application.Impl;

readonly struct TestApplication(IMenuRepository repository) : IApplication
{
    Task<IMenu> IApplication.GetCommandMenu()
    {
        return Task.FromResult<IMenu>(new Menu(repository));
    }

    Task<AppConfigure> IApplication.LoadConfigure()
    {
        throw new NotImplementedException();
    }
}