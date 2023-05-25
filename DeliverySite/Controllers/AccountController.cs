using DeliverySite.Models;
using DeliverySite.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeliverySite.Controllers;

public class AccountController : Controller
{
    private readonly SignUpRepo _signUpRepo;
    private UserManager<RegisterApp> _userManager;
    private SignInManager<RegisterApp> _signInManager;

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
    public async Task<IActionResult> RegisterAsync(RegisterApp obj)
    {
        if (ModelState.IsValid)
        {
            var user = new RegisterApp { UserName = obj.UserName ,Password = obj.Password};  // TODO this my be needed
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(obj, isPersistent: false);
                TempData["Success"] = "category created successfully";
                return RedirectToAction("index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return View(obj);
        ;
    }

    [HttpGet]
    public IActionResult LogIn(string returnURL = "")
    {
        var model = new Login() { ReturnUrl = returnURL };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> LogIn(Login model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return RedirectToAction(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
                
                
        
        }

        ModelState.AddModelError("", "Invalid username/password.");
        return View(model);
    }
}