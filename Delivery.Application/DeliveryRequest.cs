namespace Delivery.Application;

readonly struct DeliveryRequest
{
    internal static DeliveryRequest Create(string[] paramters, string[] datas)
    {
        return new(paramters, datas);
    }

    DeliveryRequest(string[] parameters, string[] datas)
    {
    }    
}