using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class LoginController : Controller
{
    private readonly LoginRepo _loginRepo;

    public LoginController(LoginRepo loginRepo)
    {
        _loginRepo = loginRepo;
    }
  
    

    // public async Task<IActionResult> LoginAsync(string username,string password)
    // {
    //     var LoginUser =await _loginRepo.FindUserNameAsync(username);
    //     
    //     if (password == LoginUser.Password)
    //     {
    //         return View();
    //     }
    //
    //     return RedirectToAction();
    // }

    public IActionResult Login()
    {
        var orders =  _loginRepo.GetAllOrders();
        return View(orders);
    }
}