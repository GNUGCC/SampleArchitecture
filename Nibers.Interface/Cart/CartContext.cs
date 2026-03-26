using ServiceHelper;

namespace Application.Interface.Cart;

public readonly struct OrderItem(string id, decimal price)
{
    public decimal Price => price;

    public Task<CartContext> PutToCart()
    {
        return ExecuteHelper.Assert(this, async context => await CartContext.Create(default, await CartHelper.GetCarter()));
    }
}

public readonly struct CartContext
{
    decimal Price { get; init; }

    string Session { get; init; }

    ICart Cart { get; init; }

    internal static Task<CartContext> Create(string session, ICart cart)
    {
        return ExecuteHelper.Assert(this, async context => Create(session, await cart.GetPrice(session), cart);
    }

    static CartContext Clone(CartContext cartContext)
    {
        return Create(cartContext.Session, cartContext.Price, cartContext.Cart);
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

    internal CartContext Clone()
    {
        return Clone(this);
    }

    internal Task<CartContext> CloneAsync()
    {
        return Create(Session, Cart);
    }

    internal async Task<CartContext> SetPrice(decimal price)
    {
        var order = Create(Session, (await Cart.PaymentCount()) * price, Cart);
        await Cart.ReplaceOrder(order);

        return order;
    }

    internal Task<CartContext> SetPrice()
    {
        return ExecuteHelper.Assert(this, context => context.SetPrice(default));
    }

    internal Task AddOrder()
    {
        return ExecuteHelper.Assert(this, context => context.Cart.AddOrder(context));
    }
}