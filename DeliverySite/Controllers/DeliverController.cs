using System.Security.Claims;
using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

[Authorize(Roles = "Admin,Delivery")]
public class DeliverController : Controller
{
    private readonly DeliverRepo _deliverRepo;
    private readonly LoginRepo _loginRepo;
    private readonly OrdersRepo _ordersRepo;
    private readonly UserManager<RegisterApp> UserManager;


    public DeliverController(LoginRepo loginRepo, DeliverRepo deliverRepo, OrdersRepo ordersRepo,
        UserManager<RegisterApp> userManager)
    {
        _loginRepo = loginRepo;
        _deliverRepo = deliverRepo;
        _ordersRepo = ordersRepo;
        this.UserManager = userManager;
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
    public async Task<IActionResult> TakingOrder(Order order)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // RegisterApp currentUser = await UserManager.GetUserAsync(User);


        // var takenOrder = new TakenOrder()
        // {
        //     FirstName = currentUser.FirstName,
        //     LastName = currentUser.LastName,
        //     PhoneNb = currentUser.PhoneNumber
        //     // OrderId = order.Id
        //
        // };
        order.IsTaken = true;

        order.DeliveryId = userId;
        await _deliverRepo.TakeOrder(order);
        var orders = _deliverRepo.GetListByDeliveyId(userId);


        return View(orders);
    }
}