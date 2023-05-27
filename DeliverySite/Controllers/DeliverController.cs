using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

[Authorize(Roles = "Admin,Delivery")]
public class DeliverController : Controller
{
    private readonly DeliverRepo _deliverRepo;
    private readonly LoginRepo _loginRepo;
    private readonly OrdersRepo _ordersRepo;


    public DeliverController(LoginRepo loginRepo, DeliverRepo deliverRepo, OrdersRepo ordersRepo)
    {
        _loginRepo = loginRepo;
        _deliverRepo = deliverRepo;
        _ordersRepo = ordersRepo;
    }


    public IActionResult Index()
    {
        var orders = _loginRepo.GetAllOrders();
        return View(orders);
    }


    [HttpGet]
    public async Task<IActionResult> TakeOrder(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);

        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> TakingOrder(Order order, RegisterApp registerApp)
    {
        // var takenOrder = new TakenOrder()
        // {
        //     FirstName = registerApp.FirstName,
        //     LastName = registerApp.LastName,
        //     DeliveryId = registerApp.Id,
        //     PhoneNb = registerApp.PhoneNb,
        //     OrderId = order.Id
        //
        // };
        await _deliverRepo.TakeOrder(order, registerApp);

        return Ok("Done");
    }
}