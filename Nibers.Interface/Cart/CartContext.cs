namespace Application.Interface.Cart;

public readonly struct CartContext
{
    decimal Price { get; init; }

    string Session { get; init; }

    ICart Cart { get; init; }

    public static CartContext Create(string session, decimal price, ICart cart)
    {
        return new()
        {
            Session = session,
            Price = price,
            Cart = cart
        };
    }    

    public static CartContext Clone(CartContext cartContext)
    {
        return Create(cartContext.Session, cartContext.Price, cartContext.Cart);
    }

    public CartContext Clone()
    {
        return Clone(this);
    }

    public async Task<CartContext> SetPrice(decimal price)
    {
        var order = Create(Session, (await Cart.PaymentCount()) * price, Cart);
        await Cart.ReplaceOrder(order);

        return order;
    }

    public Task<CartContext> SetPrice()
    {
        return SetPrice(default);
    }

    public Task AddOrder()
    {
        return Cart.AddOrder(this);
    }
}