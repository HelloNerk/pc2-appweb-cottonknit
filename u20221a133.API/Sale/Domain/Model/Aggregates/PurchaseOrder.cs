using System.ComponentModel.DataAnnotations;
using u20221a133.API.Sale.Domain.Model.Commands;

namespace u20221a133.API.Sale.Domain.Model.Aggregates;

//model
public partial class PurchaseOrder
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string Customer { get; set; }
    [Required]
    public int FabricId { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string ResumeUrl { get; set; }
    [Required]
    public int Quantity { get; set; }
    
    public PurchaseOrder()
    {
        Customer = string.Empty;
        FabricId = 0;
        City = string.Empty;
        ResumeUrl = string.Empty;
        Quantity = 0;
    }
    
    public PurchaseOrder(string customer, int fabricId, string city, string resumeUrl, int quantity)
    {
        Customer = customer;
        FabricId = fabricId;
        City = city;
        ResumeUrl = resumeUrl;
        Quantity = quantity;
    }
    
    public PurchaseOrder(CreatePurchaseOrderCommand command)
    {
        Customer = command.Customer;
        FabricId = command.FabricId;
        City = command.City;
        ResumeUrl = command.ResumeUrl;
        Quantity = command.Quantity;
    }
    
}