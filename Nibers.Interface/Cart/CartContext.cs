namespace Application.Interface.Cart;

public static class ExecuteHelper
{
    public static Task Assert<T>(T context, Func<T, Task> action)
    {
        return Assert(context, async x =>
        {
            await action.Invoke(context);
            return Task.CompletedTask;
        });
    }

    public async static Task<TResult> Assert<T, TResult>(T context, Func<T, Task<TResult>> action)
    {
        try
        {
            return await action.Invoke(context);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}

public readonly struct OrderItem(string id, decimal price)
{
    public decimal Price => price;

    public Task<CartContext> PutToCart()
    {
        return CartContext.Create(id, default);
    }
}

public readonly struct CartContext
{
    decimal Price { get; init; }

    string Session { get; init; }

    ICart Cart { get; init; }

    internal static async Task<CartContext> Create(string session, ICart cart)
    {
        return Create(session, await cart.GetPrice(session), cart);
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