using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using u20221a133.API.Sale.Domain.Model.Queries;
using u20221a133.API.Sale.Domain.Services;
using u20221a133.API.Sale.Interfaces.REST.Resources;
using u20221a133.API.Sale.Interfaces.REST.Transform;

namespace u20221a133.API.Sale.Interfaces.REST;


[ApiController]
[Route("api/v1/purchase-orders")]
[Produces(MediaTypeNames.Application.Json)]
public class PurchaseOrderController(IPurchaseOrderCommandService purchaseOrderCommandService, IPurchaseOrderQueryService purchaseOrderQueryService) :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseOrder(CreatePurchaseOrderResource resource)
    {
        var createPurchaseOrderCommand = CreatePurchaseOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var purchaseOrder = await purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
        var purchaseOrderResource = PurchaseOrderFromEntityAssembler.ToResourceFromEntity(purchaseOrder);
        return new CreatedResult(string.Empty, purchaseOrderResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPurchaseOrders()
    {
        var getAllPurchaseOrdersQuery = new GetAllPurchaseOrdersQuery();
        var purchaseOrders = await purchaseOrderQueryService.Handle(getAllPurchaseOrdersQuery);
        var purchaseOrdersResource = purchaseOrders.Select(PurchaseOrderFromEntityAssembler.ToResourceFromEntity);
        return new CreatedResult(string.Empty, purchaseOrdersResource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseOrder(int id)
    {
        var getPurchaseOrderByIdQuery = new GetPurchaseOrderByIdQuery(id);
        var purchaseOrder = await purchaseOrderQueryService.Handle(getPurchaseOrderByIdQuery);
        if (purchaseOrder == null)
            return NotFound();
        var purchaseOrderResource = PurchaseOrderFromEntityAssembler.ToResourceFromEntity(purchaseOrder);
        return new CreatedResult(string.Empty, purchaseOrderResource);
    }
}
