using System.ComponentModel.DataAnnotations;

namespace DeliverySite.ViewModel;

public class CreateRoleViewModel
{
    [Required] public string RoleName { get; set; }
}