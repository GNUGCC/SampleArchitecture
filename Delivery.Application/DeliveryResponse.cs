using Newtonsoft.Json;

namespace Delivery.Application;

public readonly struct DeliveryResponse(string[] paramters, string[] datas)
{
    public static DeliveryResponse Create(string json)
    {
        return JsonConvert.DeserializeObject<DeliveryResponse>(json);
    }

    public static DeliveryResponse Create(string[] paramters, string[] datas)
    {
        return new(paramters, datas);
    }
}