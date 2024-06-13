namespace u20221a133.API.Sale.Interfaces.REST.Resources;

public record CreatePurchaseOrderResource(string Customer,int FabricId,string City,string ResumeUrl,int Quantity);