namespace Application.Interface.Cart;

public interface ICart
{
    Task<bool> AddOrder(CartContext cart);

    Task<bool> AddOrder(ICollection<CartContext> carts);

    Task<CartContext> ReplaceOrder(CartContext cart);

    Task<CartContext> QueryCartConfigure();

    Task<decimal> PaymentCount();

    Task<decimal> GetPrice(string id);
}