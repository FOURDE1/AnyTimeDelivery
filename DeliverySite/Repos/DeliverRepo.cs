using DeliverySite.Data;
using DeliverySite.Models;

namespace DeliverySite.Repos;

public class DeliverRepo
{
    private readonly ApplicationDbContext _db;

    public DeliverRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task TakeOrder(Order order, RegisterApp registerApp)
    {
        var takenOrder = new TakenOrder
        {
            DeliveryId = registerApp.Id,
            FirstName = "Abbes",
            LastName = "Moussawi",
            PhoneNb = 81753181,
            OrderId = order.Id
        };
        _db.TakenOrders.AddAsync(takenOrder);
        await _db.SaveChangesAsync();
    }
}