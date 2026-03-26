using Application.Interface.Cart;

namespace Domain.Application.Cart;

public readonly struct TestCartLogic : ICart
{
    Task<bool> ICart.AddOrder(CartContext cart)
    {
        return Task.FromResult(true);
    }

    Task<bool> ICart.AddOrder(ICollection<CartContext> carts)
    {
        return Task.FromResult(true);
    }

    Task<decimal> ICart.GetPrice(string id)
    {
        return Task.FromResult<decimal>(1);
    }

    Task<decimal> ICart.PaymentCount()
    {
        return Task.FromResult<decimal>(10);
    }

    async Task<CartContext> ICart.QueryCartConfigure()
    {
        return await CartContext.Create($"{1}", default);
    }

    async Task<CartContext> ICart.ReplaceOrder(CartContext cart)
    {
        return await CartContext.Create($"{2}", default);
    }
}