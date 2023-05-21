using DeliverySite.Data;
using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class SignUpController : Controller
{
    private readonly SignUpRepo _ordersRepo;

    public SignUpController(SignUpRepo ordersRepo)
    {
        _ordersRepo = ordersRepo;
    }
    public IActionResult Register()
    {
        return View();
    }

    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAsync(RegisterApp obj)
    {
        // if (!ModelState.IsValid)
        // {
        //     return View("Register", obj);
        // }
        await _ordersRepo.CreateRegisterAppAsync(obj);
        TempData["Success"] = "category created successfully";
        return RedirectToAction("Register");
    }
}