using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.ValueObjects;
using u20221a133.API.Shared.Domain.Repositories;

namespace u20221a133.API.Sale.Domain.Repositories;

public interface IPurchaseOrderRepository:IBaseRepository<PurchaseOrder>
{
    Task<PurchaseOrder?> FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId);
}