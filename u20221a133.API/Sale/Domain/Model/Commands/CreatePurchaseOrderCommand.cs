namespace u20221a133.API.Sale.Domain.Model.Commands;

public record CreatePurchaseOrderCommand(string Customer, int FabricId, string City, string ResumeUrl, int Quantity);