using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.Commands;

namespace u20221a133.API.Sale.Domain.Services;

public interface IPurchaseOrderCommandService
{
    public Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command);
}