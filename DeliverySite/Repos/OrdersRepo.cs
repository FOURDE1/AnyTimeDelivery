using DeliverySite.Data;
using DeliverySite.Models;

namespace DeliverySite.Repos;

public class OrdersRepo
{
    private readonly ApplicationDbContext _db;

    public OrdersRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<Order> GetAllOrders()
    {
        var ordersList = _db.Orders.ToList();
        return ordersList;
    }


    public async Task<Order> GetOrderByIdAsync(int? id)
    {
        return await _db.Orders.FindAsync(id);
    }

    public async Task AddAsync(Order order)
    {
        _db.Orders.Add(order);
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error in creating order", e);
        }
    }

    public void UpdateAsync(Order order)
    {
        _db.Orders.Update(order);

        _db.SaveChanges();
    }


    public async Task DeleteAsync(int id)
    {
        var orderToDelete = await _db.Orders.FindAsync(id);
        _db.Orders.Remove(orderToDelete);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("error on deleting");
            throw;
        }
    }
}