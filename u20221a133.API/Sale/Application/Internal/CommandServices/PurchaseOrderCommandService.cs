using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.Commands;
using u20221a133.API.Sale.Domain.Model.ValueObjects;
using u20221a133.API.Sale.Domain.Repositories;
using u20221a133.API.Sale.Domain.Services;
using u20221a133.API.Shared.Domain.Repositories;

namespace u20221a133.API.Sale.Application.Internal.CommandServices;

public class PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork) : IPurchaseOrderCommandService
{
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        try
        {
            var existingPurchaseOrderWithCAndF = await purchaseOrderRepository.FindByCustomerAndFabricIdAsync(command.Customer, (EFabric)command.FabricId);
            if (existingPurchaseOrderWithCAndF != null)
            {
                throw new ArgumentException("A purchase order with the same Customer and FabricId already exists.");
            }
        
            if(!Enum.IsDefined(typeof(EFabric), command.FabricId))
            {
                throw new ArgumentException("FabricId must be a valid value.");
            }
            
            var purchaseOrder = new PurchaseOrder(command);
            await purchaseOrderRepository.AddAsync(purchaseOrder);
            await unitOfWork.CompleteAsync();
            return purchaseOrder;
        }catch(ArgumentException e)
        {
            throw new Exception(e.Message);
        }

    }
}