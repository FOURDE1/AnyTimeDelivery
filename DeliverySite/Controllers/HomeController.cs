using Microsoft.AspNetCore.Mvc;
using DeliverySite.Models;
using DeliverySite.Repos;

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


    [HttpGet]
    public IActionResult CreateOrder()
    {
        return View(nameof(Index));
    }

    // OrderController
    [HttpPost]
    // public async Task<IActionResult> createOrder(order Order)
    public async Task<RedirectToActionResult> CreateOrder(Order order)

    {
        try
        {
            if (ModelState.IsValid)
            {
                await _ordersRepo.AddAsync(order);
                Console.WriteLine("Order added successfully."); // Debug statement
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding order: {ex.Message}"); // Debug statement
            throw new Exception("Error in creating form", ex);
        }

        // return RedirectToAction(nameof(getAllOrders));
        // return View(nameof(getAllOrders));
        // return RedirectToAction(nameof(getAllOrders));
        return RedirectToAction(nameof(getAllOrders));
    }


    [HttpGet]
    public  IActionResult getAllOrders()
    {
        var orders =  _ordersRepo.GetAllOrders();
        return View(orders);
    }


    [HttpGet]
    public async Task<IActionResult> EditOrder(int id)
    {
        var Order = await _ordersRepo.GetOrderByIdAsync(id);
        if (id == null || Order == null)
        {
            return NotFound();
        }

        var updatedOrder = new Order()
        {
            Id = Order.Id,
            Type = Order.Type,
            OrderDate = Order.OrderDate,
            NameOfRecipient = Order.NameOfRecipient,
            DropOffLocation = Order.DropOffLocation,
            PickUpLocation = Order.PickUpLocation,
            Comments = Order.Comments
        };
        _ordersRepo.DeleteAsync(id);


        return View(updatedOrder);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Order order)
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


    public async Task<IActionResult> DeleteOrder(int id)
    {
        var Order = await _ordersRepo.GetOrderByIdAsync(id);
        if (Order == null) return View("error");

        return View(Order);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        Order order = await _ordersRepo.GetOrderByIdAsync(id);
        if (order == null)
        {
            return View("Error");
        }

        if (ModelState.IsValid)
        {
            await _ordersRepo.DeleteAsync(id);
        }

        return RedirectToAction(nameof(getAllOrders));
    }

  
}