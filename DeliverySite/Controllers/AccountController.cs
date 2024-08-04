using DeliverySite.Models;
using DeliverySite.Repos;
using DeliverySite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<RegisterApp> _signInManager;
    private readonly SignUpRepo _signUpRepo;
    private readonly UserManager<RegisterApp> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(SignUpRepo signUpRepo, UserManager<RegisterApp> userManager,
        SignInManager<RegisterApp> signInManager,RoleManager<IdentityRole> roleManager)
    {
        _signUpRepo = signUpRepo;
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAsync(RegisterAppViewModel obj,string UserType)
    {
        if (UserType =="delivery")
        {
            obj.IsADelivery = true;

        }
        else
        {
            obj.IsADelivery = false;
        }
        if (ModelState.IsValid)
        {
            var user = new RegisterApp
            {
                UserName = obj.UserName, Password = obj.Password, PhoneNumber = obj.PhoneNumber, ImageDataDriverLi = obj.ImageDataDriverLi,
                FirstName = obj.FirstName, LastName = obj.LastName, Email = obj.Email, NationalId = obj.NationalId, IsADelivery = obj.IsADelivery,
                City = obj.City, Payment = obj.Payment, VerifyPassword1 = obj.VerifyPassword1,DeliveryVehicle = obj.DeliveryVehicle,ImageDataSelfie = obj.ImageDataSelfie 
            };
            
            
            
            var result = await _userManager.CreateAsync(user, obj.Password);
            if(user.IsADelivery){
                var role = await _roleManager.FindByNameAsync("Delivery");
                await _userManager.AddToRoleAsync(user, role.Name);
                
            }
            else
            {
                var role = await _roleManager.FindByNameAsync("Client");
                await _userManager.AddToRoleAsync(user, role.Name);
            }
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                TempData["Success"] = "Registered successfully";
                return RedirectToAction("index", "Home");
            }

            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
        }

        return View(obj);
        
    }

    [HttpGet]
    public IActionResult LogIn(string returnURL = "")
    {
        var model = new Login { ReturnUrl = returnURL };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(Login model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                false);
            if (result.Succeeded)
            {
                TempData["Success"] = "Logged in successfully";
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
            
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError("", "Invalid username/password.");
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> LogInFromHomePage(Login model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                false);
            if (result.Succeeded)
            {
                TempData["Success"] = "Logged in successfully";
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
            
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError("", "Invalid username/password.");
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        
        await _signInManager.SignOutAsync();
        TempData["Success"] = "logged out successfully";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }
}