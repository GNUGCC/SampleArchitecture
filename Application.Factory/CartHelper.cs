using Application.Interface.Cart;
using Domain.Application.Cart;

namespace Application.Factory;

public static class CartHelper
{
    public static Task<ICart> GetCarter()
    {
        return Task.FromResult<ICart>(new TestCartLogic());
    }   
}