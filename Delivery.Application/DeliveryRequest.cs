namespace Delivery.Application;

public readonly struct DeliveryRequest(string[] parameters, string[] datas)
{
    internal string[] Parameters => parameters;

    internal string[] Datas => datas;

    internal static DeliveryRequest Create(string[] paramters, string[] datas)
    {
        return new(paramters, datas);
    }
}