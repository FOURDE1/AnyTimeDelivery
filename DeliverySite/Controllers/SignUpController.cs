using DeliverySite.Data;
using DeliverySite.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class SignUpController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public SignUpController(ApplicationDbContext db)
    {
        _db = db;
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
        await _db.RegisterApps.AddAsync(obj);
        await _db.SaveChangesAsync();
        TempData["Success"] = "category created successfully";
        return RedirectToAction("Register");
    }
}