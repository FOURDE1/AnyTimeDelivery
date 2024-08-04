using System.Security.Claims;
using DeliverySite.Models;
using DeliverySite.Repos;
using DeliverySite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class Home : Controller
{
    private readonly OrdersRepo _ordersRepo;
    private readonly UserManager<RegisterApp> _userManager;
    public Home(OrdersRepo ordersRepo,UserManager<RegisterApp>userManager)
    {
        _userManager = userManager;
        _ordersRepo = ordersRepo;
    }

    // GET

    public IActionResult Index()
    {
        var orderRegisterAppLoginViewData = new OrderRegisterAppLoginViewData
        {
            registerApp = new RegisterApp(),
            order = new Order(),
            login = new Login()
        };
        return View(orderRegisterAppLoginViewData);
    }

    [Authorize]
    [HttpGet]
    public IActionResult CreateOrder()
    {
        return View(nameof(Index));
    }
    [HttpGet]
    public IActionResult CreateOrderInSeparatedPage()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    // public async Task<IActionResult> createOrder(order Order)
    public async Task<RedirectToActionResult> CreateOrderInSeparatedPage(Order order)

    { if (!ModelState.IsValid)
        {
            // Handle invalid model state
            return RedirectToAction("CreateOrderInSeparatedPage", order);
        }

        // Get the currently authenticated user's identity user ID
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Set the RegisterAppId property of the order to the identity user ID
        order.RegisterAppId = userId;

        // Add the order to the repository
        await _ordersRepo.AddAsync(order);

        TempData["Success"] = "Order created successfully";
        return RedirectToAction(nameof(getAllOrders));
    }

    // OrderController
    [Authorize]
    [HttpPost]
    public async Task<RedirectToActionResult> CreateOrder(Order order)
    {
        if (!ModelState.IsValid)
        {
            // Handle invalid model state
            return RedirectToAction("CreateOrderInSeparatedPage", order);
        }

        // Get the currently authenticated user's identity user ID
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Set the RegisterAppId property of the order to the identity user ID
        order.RegisterAppId = userId;

        // Add the order to the repository
        await _ordersRepo.AddAsync(order);

        TempData["Success"] = "Order created successfully";
        return RedirectToAction(nameof(getAllOrders));
    }




    [Authorize]
    [HttpGet]
    public IActionResult getAllOrders()
    {
        if (User.IsInRole("Admin"))
        {
            var orders = _ordersRepo.GetAllOrders();
            return View(orders);
        }
        else
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _ordersRepo.GetOrdersByRegisterAppId(userId);
            return View(orders);
        }
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditOrder(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);

        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> EditOrder(Order order)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Failed to edit order");
            return View("EditOrder", order);
        }

        var existingOrder = await _ordersRepo.GetOrderByIdAsync(order.Id);
        if (existingOrder != null)
        {
            existingOrder.TypeOfCategories = order.TypeOfCategories;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.NameOfRecipient = order.NameOfRecipient;
            existingOrder.PickUpLocation = order.PickUpLocation;
            existingOrder.DropOffLocation = order.DropOffLocation;
            existingOrder.Comments = order.Comments;

            _ordersRepo.UpdateAsync(existingOrder);
            TempData["Success"] = "Order Edited successfully";
        }

        return RedirectToAction(nameof(getAllOrders));
    }


    [Authorize]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var Order = await _ordersRepo.GetOrderByIdAsync(id);
        if (Order == null) return View("error");

        return View(Order);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _ordersRepo.GetOrderByIdAsync(id);
        if (order == null) return View("Error");

        if (ModelState.IsValid) await _ordersRepo.DeleteAsync(id);
        TempData["Success"] = "Order Deleted successfully";
        return RedirectToAction(nameof(getAllOrders));
    }

    [HttpGet]
    public IActionResult AboutUs()
    {
        return View();
    }
}