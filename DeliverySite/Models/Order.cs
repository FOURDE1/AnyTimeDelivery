using System.ComponentModel.DataAnnotations;

namespace DeliverySite.Models;

public class Order
{
    [Key] public int Id { get; set; }

    [Required] public string Type { get; set; }

    public DateTime OrderDate { get; set; }
    [Required] public string NameOfRecipient { get; set; }
    [Required] public string PickUpLocation { get; set; }
    [Required] public string DropOffLocation { get; set; }

    public string? Comments { get; set; }
    // [Range(1, 10000000)] public decimal Price { get; set; }
}