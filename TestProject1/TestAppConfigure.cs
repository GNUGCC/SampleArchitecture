using Delivery.Application;
using Domain.Application;
using Application.Impl;
using Infranstracture.Test;

namespace TestProject1;

sealed class TestAppConfigure : IUnitTest
{
    async Task IUnitTest.Run()
    {
        var request = DeliveryRequest.Create(["Test1", "Test2"], ["Data1", "Data2"]);
        IDevlieryApplication delivery = new TestApplication(new TestDomainApplication(new DomainRepository()));
        var query = await delivery.QueryAppConfigure(request.Parameters.First(), request.Datas);
        var response = DeliveryResponse.Create(query);
    }
}