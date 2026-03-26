using Application.Interface.Cart;
using ServiceHelper;

namespace Application.Factory;

public readonly struct OrderItem(string id, decimal price)
{
    public decimal Price => price;

    public static Task<CartContext> PutToCart(string id)
    {
        return ExecuteHelper.Assert(async () => await CartContext.Create(id, await CartHelper.GetCarter()));
    }

    public Task<CartContext> PutToCart()
    {
        return PutToCart(id);
    }
}