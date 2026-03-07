namespace Application.Interface.Cart;

public interface ICart
{
    Task<bool> AddOrder();
}