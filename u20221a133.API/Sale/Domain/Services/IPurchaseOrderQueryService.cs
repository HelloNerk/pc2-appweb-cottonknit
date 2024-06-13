using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.Queries;

namespace u20221a133.API.Sale.Domain.Services;

public interface IPurchaseOrderQueryService
{
    Task<PurchaseOrder?> Handle(GetPurchaseOrderByIdQuery query);
    Task<IEnumerable<PurchaseOrder>> Handle(GetAllPurchaseOrdersQuery query);
}