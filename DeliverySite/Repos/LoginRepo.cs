using DeliverySite.Data;
using DeliverySite.Models;
using Microsoft.AspNetCore.Mvc;

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

    public List<Order> GetAllOrders(string userId, bool isAdmin)
    {
        var query = _db.Orders.AsQueryable();

        if (!isAdmin)
        {
            query = query.Where(order => order.RegisterAppId != userId);
        }

        var ordersList = query.ToList();
        return ordersList;
    }


    // public IActionResult addOrder(int id)
    // {
    //
    // }
}