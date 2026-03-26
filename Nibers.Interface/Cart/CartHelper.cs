namespace Application.Interface.Cart;

public static class CartHelper
{
    public static Task<ICart> GetCarter()
    {
        return Task.FromResult<ICart>(default);
    }
}