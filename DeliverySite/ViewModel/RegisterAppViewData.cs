using System.ComponentModel.DataAnnotations;

public class RegisterAppViewData
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a username.")]
    [StringLength(255)]
    public string UserName { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }
    [Required] public string Email { get; set; }
    public string PhoneNumber { get; set; }


    // [Required]
    // [StringLength(20, MinimumLength = 6)]
    // [RegularExpression(@"^(?![_-])(?!.*[_-]{2})[a-zA-Z0-9_-]{4,20}(?<![_-])$",
    //     ErrorMessage = "Invalid username format.")]


    [Required]
    // [RegularExpression(@"^0000\d{8}$",
    //     ErrorMessage = "Invalid username format. The National ID should start with 4 zeros followed by 8 numbers.")]
    public long NationalId { get; set; }

    [Required] public string City { get; set; }
    [Required] public bool IsADelivery { get; set; } = true;
    public string? ImageDataDriverLi { get; set; }

    public string? ImageDataSelfie { get; set; }
    [Required] public string Payment { get; set; }
    public string? DeliveryVehicle { get; set; }

    [Required(ErrorMessage = "You must agree to the terms and conditions.")]
    public bool TermsAndConditions { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter a password.")]
    public string Password { get; set; } // Property to store the input value of the password

    [Required(ErrorMessage = "Please confirm your password.")]
    public string VerifyPassword1 { get; set; }
}