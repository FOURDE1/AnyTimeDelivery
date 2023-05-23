using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DeliverySite.Models;

public class TakenOrder
{
    [Key] public int Id { get; set; }
    public int DeliveryId { get; set; }
    public int OrderId { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^(\+961|0)?\d{8}$")]
    public int PhoneNb { get; set; }
}