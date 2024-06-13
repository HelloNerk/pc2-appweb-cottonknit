using Microsoft.EntityFrameworkCore;
using u20221a133.API.Sale.Domain.Model.Aggregates;
using u20221a133.API.Sale.Domain.Model.ValueObjects;
using u20221a133.API.Sale.Domain.Repositories;
using u20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using u20221a133.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace u20221a133.API.Sale.Infrastructure.Persistence.EFC.Repositories;

public class PurchaseOrderRepository(AppDbContext context): BaseRepository<PurchaseOrder>(context), IPurchaseOrderRepository
{
    public async Task<PurchaseOrder?>FindByCustomerAndFabricIdAsync(string customer, EFabric fabricId)
    {
        return await Context.Set<PurchaseOrder>()
            .FirstOrDefaultAsync(p=>p.Customer == customer && p.FabricId== (int)fabricId);
    }
}