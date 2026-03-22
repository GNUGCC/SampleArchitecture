namespace Delivery.Application;

public interface IDevlieryApplication
{
    Task<DeliveryResponse> QueryAppConfigure(DeliveryRequest request);

    Task<string> QueryAppConfigure(string id, string[] datas);

    Task<DeliveryResponse> InitClientSystem(DeliveryRequest request);

    Task<DeliveryResponse> GetMenuConfigure(DeliveryRequest request);
}