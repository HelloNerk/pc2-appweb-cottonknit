using u20221a133.API.Sale.Domain.Model.Commands;
using u20221a133.API.Sale.Interfaces.REST.Resources;

namespace u20221a133.API.Sale.Interfaces.REST.Transform;

public class CreatePurchaseOrderCommandFromResourceAssembler
{
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource)
    {
        return new CreatePurchaseOrderCommand(resource.Customer, resource.FabricId, resource.City, resource.ResumeUrl, resource.Quantity);
    }
}