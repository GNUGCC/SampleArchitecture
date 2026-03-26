using Application.Factory;

namespace TestProject1;

sealed class TestCart : IUnitTest
{
    async Task IUnitTest.Run()
    {
        var orderitem = new OrderItem(default, default);
        Assert.That(orderitem.Price, Is.EqualTo(0));

        var cart = await orderitem.PutToCart();
        Assert.That(orderitem.Price, Is.EqualTo(0));

        await cart.SetPrice(100);
        Assert.That(orderitem.Price, Is.EqualTo(100));

        var neworder = new OrderItem(default, 1000);
        Assert.That(orderitem.Price, Is.EqualTo(1000));

        var newcart = await orderitem.PutToCart();
        Assert.That(orderitem.Price, Is.EqualTo(1000));

        await cart.SetPrice(3000);
        Assert.That(orderitem.Price, Is.EqualTo(3000));
    }
}