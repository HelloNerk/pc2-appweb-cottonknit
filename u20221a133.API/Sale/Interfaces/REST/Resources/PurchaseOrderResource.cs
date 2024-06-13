namespace u20221a133.API.Sale.Interfaces.REST.Resources;

public record PurchaseOrderResource(int Id, string Customer, int FabricId, string City, string ResumeUrl, int Quantity);