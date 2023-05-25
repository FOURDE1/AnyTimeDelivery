using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Controllers;

public class AccountController : Controller
{
    private readonly SignUpRepo _signUpRepo;
    private readonly SignInManager<RegisterApp> _signInManager;
    private readonly UserManager<RegisterApp> _userManager;

    public AccountController(SignUpRepo signUpRepo, UserManager<RegisterApp> userManager,
        SignInManager<RegisterApp> signInManager)
    {
        _signUpRepo = signUpRepo;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAsync(RegisterAppViewData obj)
    {
        if (ModelState.IsValid)
        {
            var user = new RegisterApp
            {
                UserName = obj.UserName, Password = obj.Password, PhoneNumber = obj.PhoneNumber,
                FirstName = obj.FirstName, LastName = obj.LastName, Email = obj.Email, NationalId = obj.NationalId,
                City = obj.City, Payment = obj.Payment, VerifyPassword1 = obj.VerifyPassword1
            }; // TODO this my be needed
            // var username = user.UserName;
            var result = await _userManager.CreateAsync(user, obj.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                TempData["Success"] = "category created successfully";
                return RedirectToAction("index", "Home");
            }

            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
        }

        return View(obj);
        ;
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
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return RedirectToAction(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError("", "Invalid username/password.");
        return View(model);
        // return Ok("Done");
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}