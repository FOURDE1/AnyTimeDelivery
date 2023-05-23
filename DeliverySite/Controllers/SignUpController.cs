using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class SignUpController : Controller
{
    private readonly SignUpRepo _signUpRepo;

    public SignUpController(SignUpRepo signUpRepo)
    {
        _signUpRepo = signUpRepo;
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
        await _signUpRepo.CreateRegisterAppAsync(obj);
        TempData["Success"] = "category created successfully";
        return RedirectToAction("Register");
    }
}