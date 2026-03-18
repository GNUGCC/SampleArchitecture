using Application.Interface.Cart;

namespace Domain.Application.Cart;

readonly struct CartLogic : ICart
{
    Task<bool> ICart.AddOrder()
    {
        throw new NotImplementedException();
    }

    Task<CartConfigure> ICart.QueryCartConfigure()
    {
        throw new NotImplementedException();
    }
}