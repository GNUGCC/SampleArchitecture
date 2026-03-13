using Application.Interface.Cart;

namespace Application.Impl.Cart;

readonly struct CartLogic : ICart
{
    Task<bool> ICart.AddOrder()
    {
        throw new NotImplementedException();
    }
}