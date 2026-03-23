namespace Delivery.Application;

public readonly struct DeliveryRequest(string[] parameters, string[] datas)
{
    public string[] Parameters => parameters;

    public string[] Datas => datas;

    public static DeliveryRequest Create(string[] paramters, string[] datas)
    {
        return new(paramters, datas);
    }
}