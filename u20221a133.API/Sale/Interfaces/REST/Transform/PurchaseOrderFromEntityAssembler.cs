using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Interfaces.REST.Resources;

namespace u20221a133.API.Sale.Interfaces.REST.Transform;

public class PurchaseOrderFromEntityAssembler
{
    public static PurchaseOrderResource ToResourceFromEntity(PurchaseOrder entity)
    {
        return new PurchaseOrderResource(entity.Id, entity.Customer, entity.FabricId, entity.City, entity.ResumeUrl, entity.Quantity);
    }
}