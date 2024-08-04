using DeliverySite.Data;
using DeliverySite.Models;
using DeliverySite.ViewModel;

namespace DeliverySite.Repos;

public class DeliverRepo
{
    private readonly ApplicationDbContext _db;

    public DeliverRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task TakeOrder(Order order)
    {
        _db.Orders.Update(order);
        await _db.SaveChangesAsync();
       
       {
           
       }
    }

    public List<Order> GetListByDeliveyId(string id)
    {
        return _db.Orders.Where(o => o.DeliveryId == id).ToList();
    }
}