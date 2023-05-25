using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;


public class Home : Controller
{
    private readonly OrdersRepo _ordersRepo;

    public Home(OrdersRepo ordersRepo)
    {
        _ordersRepo = ordersRepo;
    }

    // GET
    
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    [HttpGet]
    public IActionResult CreateOrder()
    {
        return View(nameof(Index));
    }

    // OrderController
    [Authorize]
    [HttpPost]
    // public async Task<IActionResult> createOrder(order Order)
    public async Task<RedirectToActionResult> CreateOrder(Order order)

    {
        try
        {
            if (ModelState.IsValid)
                await _ordersRepo.AddAsync(order);
            else
                return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding order: {ex.Message}"); // Debug statement
        }

        // return RedirectToAction(nameof(getAllOrders));
        // return View(nameof(getAllOrders));
        // return RedirectToAction(nameof(getAllOrders));
        return RedirectToAction(nameof(getAllOrders));
    }

    [Authorize]
    [HttpGet]
    public IActionResult getAllOrders()
    {
        var orders = _ordersRepo.GetAllOrders();
        return View(orders);
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
            ModelState.AddModelError("", "Failed to edit club");
            return View("EditOrder", order);
        }

        // await _ordersRepo.DeleteAsync(id);
        // Delete(id);


        // var updatedOrder = new order()
        // {
        //     
        //     Type = Order.Type,
        //     orderDate = Order.orderDate,
        //     nameOfRecipient = Order.nameOfRecipient,
        //     dropOffLocation = Order.dropOffLocation,
        //     pickUpLocation = Order.pickUpLocation,
        //     comments = Order.comments
        // };
        _ordersRepo.UpdateAsync(order);
        // _ordersRepo.DeleteAsync(id - 1);

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

        return RedirectToAction(nameof(getAllOrders));
    }
}