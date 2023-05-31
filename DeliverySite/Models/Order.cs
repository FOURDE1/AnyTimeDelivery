using System.ComponentModel.DataAnnotations;

namespace DeliverySite.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    public string TypeOfCategories { get; set; } 

    public DateTime OrderDate { get; set; }

    [Required]
    public string NameOfRecipient { get; set; }

    [Required]
    public string PickUpLocation { get; set; }

    [Required]
    public string DropOffLocation { get; set; }

    public string? Comments { get; set; }
    public bool IsTaken { get; set; } = false;
    public string DeliveryId { get; set; } = "";
   

    public string RegisterAppId { get; set; } // Foreign key to the identity user ID
    // [Range(1, 10000000)] public decimal Price { get; set; }
}