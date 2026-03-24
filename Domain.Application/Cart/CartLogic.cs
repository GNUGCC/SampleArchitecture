using Application.Interface.Cart;

namespace Domain.Application.Cart;

readonly struct CartLogic : ICart
{
    Task<bool> ICart.AddOrder(CartContext cart)
    {
        throw new NotImplementedException();
    }

    Task<bool> ICart.AddOrder(ICollection<CartContext> carts)
    {
        throw new NotImplementedException();
    }

    Task<decimal> ICart.PaymentCount()
    {
        throw new NotImplementedException();
    }

    Task<CartContext> ICart.QueryCartConfigure()
    {
        throw new NotImplementedException();
    }

    Task<CartContext> ICart.ReplaceOrder(CartContext cart)
    {
        throw new NotImplementedException();
    }
}