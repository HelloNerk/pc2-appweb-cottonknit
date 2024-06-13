using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.Queries;
using u20221a133.API.Sale.Domain.Repositories;
using u20221a133.API.Sale.Domain.Services;

namespace u20221a133.API.Sale.Application.Internal.QueryServices;

public class PurchaseOrderQueryService(IPurchaseOrderRepository purchaseOrderRepository):IPurchaseOrderQueryService
{
    public async Task<PurchaseOrder?> Handle(GetPurchaseOrderByIdQuery query)
    {
        return await purchaseOrderRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<PurchaseOrder>> Handle(GetAllPurchaseOrdersQuery query)
    {
        return await purchaseOrderRepository.ListAsync();
    }
}