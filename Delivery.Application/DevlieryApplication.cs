namespace Delivery.Application;

public interface IDevlieryApplication
{
    Task<DeliveryResponse> QueryAppConfigure(DeliveryRequest request);

    Task<DeliveryResponse> InitClientSystem(DeliveryRequest request);

    Task<DeliveryResponse> GetMenuConfigure(DeliveryRequest request);
}