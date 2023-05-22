using DeliverySite.Data;
using DeliverySite.Models;

namespace DeliverySite.Repos;

public class LoginRepo
{
    private readonly ApplicationDbContext _db;

    public LoginRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RegisterApp?> FindUserNameAsync(string username)
    {
        return await _db.RegisterApps.FindAsync(username);

    }
    public  List<Order> GetAllOrders()
    {
        List<Order> ordersList = _db.Orders.ToList();
        return  ordersList;
    }
}