using DeliverySite.Models;

namespace DeliverySite.ViewModel;

public class OrderRegisterAppLoginViewData
{
    public RegisterApp registerApp { get; set; }
    public Order order { get; set; }
    public Login login { get; set; }
}