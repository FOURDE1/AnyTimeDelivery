using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
        var user = UserManager.FindByIdAsync(userId).Result;
        var isAdmin = UserManager.IsInRoleAsync(user, "Admin").Result;
        var orders = _loginRepo.GetAllOrders(userId,isAdmin);
     
        return View(orders);
    }


    [HttpGet]
    public async Task<IActionResult> TakeOrder(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);

        return View(order);
    }
    [HttpGet]
    public async Task<IActionResult> TakedOrder()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var orders = _deliverRepo.GetListByDeliveyId(userId);
        return View("TakingOrder",orders);
    }

    [HttpPost]
    public async Task<IActionResult> TakingOrder(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // RegisterApp currentUser = await UserManager.GetUserAsync(User);

        var existingOrder = order;
        if (existingOrder != null)
        {
            existingOrder.TypeOfCategories = order.TypeOfCategories;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.NameOfRecipient = order.NameOfRecipient;
            existingOrder.PickUpLocation = order.PickUpLocation;
            existingOrder.DropOffLocation = order.DropOffLocation;
            existingOrder.Comments = order.Comments;
            existingOrder.IsTaken = true;
            existingOrder.DeliveryId = userId;
            
            await _deliverRepo.TakeOrder(existingOrder);
            TempData["Success"] = "Order taken";
        }
        


        
        
        var orders = _deliverRepo.GetListByDeliveyId(userId);


        return View(orders);
    }
    public async Task<IActionResult> Cancel(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // RegisterApp currentUser = await UserManager.GetUserAsync(User);

        var existingOrder = order;
        if (existingOrder != null)
        {
            existingOrder.TypeOfCategories = order.TypeOfCategories;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.NameOfRecipient = order.NameOfRecipient;
            existingOrder.PickUpLocation = order.PickUpLocation;
            existingOrder.DropOffLocation = order.DropOffLocation;
            existingOrder.Comments = order.Comments;
            existingOrder.IsTaken = false;
            existingOrder.DeliveryId = userId;
            
            await _deliverRepo.TakeOrder(existingOrder);
            TempData["Success"] = "Order taken";
        }
        


        
        
        var orders = _deliverRepo.GetListByDeliveyId(userId);


        return View("TakingOrder",orders);
    }
}