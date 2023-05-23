using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace DeliverySite.Models;

public class RegisterApp
{
    [Key] public int Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 6)]
    [RegularExpression(@"^(?![_-])(?!.*[_-]{2})[a-zA-Z0-9_-]{4,20}(?<![_-])$",
        ErrorMessage = "Invalid username format.")]
    public string UserName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [RegularExpression(@"^(\+961|0)?\d{8}$")]
    public int PhoneNb { get; set; }

    [Required]
    [RegularExpression(@"^0000\d{8}$",
        ErrorMessage = "Invalid username format. The National ID should start with 4 zeros followed by 8 numbers.")]
    public long NationalId { get; set; }

    [Required] public string City { get; set; }
    [Required] public bool IsADelivery { get; set; }
    public string? ImageDataDriverLi { get; set; }

    public string? ImageDataSelfie { get; set; }
    [Required] public string Payment { get; set; }
    public string? DeliveryVehicle { get; set; }

    [Required(ErrorMessage = "You must agree to the terms and conditions.")]
    public bool TermsAndConditions { get; set; }

    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } // Property to store the input value of the password

    [Required] public string VerifyPassword1 { get; set; }

    private string HashedPassword { get; set; }

    [DataType(DataType.Password)]
    public void SetPassword(string password)
    {
        // Hash the password using a secure hashing algorithm (e.g., SHA256)
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        HashedPassword = Convert.ToBase64String(hashedBytes);
    }

    public string VerifyPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hashedPassword = Convert.ToBase64String(hashedBytes);

        return HashedPassword != hashedPassword
            ? "The passwords do not match."
            : string.Empty; // Return an empty string if the passwords match.
    }
}