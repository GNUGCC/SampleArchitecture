using ServiceHelper;

namespace Application.Interface.Cart;

public readonly struct CartContext
{
    decimal Price { get; init; }

    string Session { get; init; }

    ICart Cart { get; init; }

    public static Task<CartContext> Create(string session, ICart cart)
    {
        return ExecuteHelper.Assert(async () => Create(session, await cart.GetPrice(session), cart));
    }

    static Task<CartContext> Clone(CartContext cartContext)
    {
        return ExecuteHelper.Assert(() => Task.FromResult(Create(cartContext.Session, cartContext.Price, cartContext.Cart)));
    }

    static CartContext Create(string session, decimal price, ICart cart)
    {
        return new()
        {
            Session = session,
            Price = price,
            Cart = cart
        };
    }

    public Task<CartContext> Clone()
    {
        return Clone(this);
    }

    public Task<CartContext> CloneAsync()
    {
        return Create(Session, Cart);
    }

    public async Task<CartContext> SetPrice(decimal price)
    {
        var order = Create(Session, (await Cart.PaymentCount()) * price, Cart);
        await Cart.ReplaceOrder(order);

        return order;
    }

    public Task<CartContext> SetPrice()
    {
        return ExecuteHelper.Assert(this, context => context.SetPrice(default));
    }

    public Task AddOrder()
    {
        return ExecuteHelper.Assert(this, context => context.Cart.AddOrder(context));
    }
}