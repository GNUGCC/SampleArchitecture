namespace Delivery.Application;

public readonly struct DeliveryResponse
{
    internal static DeliveryResponse Create(string[] paramters, string[] datas)
    {
        return new(paramters, datas);
    }

    DeliveryResponse(string[] parameters, string[] datas)
    {
    }
}