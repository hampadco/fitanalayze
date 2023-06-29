using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.user;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace App.Controllers.user;

public class DashboardController : BaseController
{
    private readonly Context _context;
    public DashboardController(Context context) 
    {
        _context = context;
    }
    
   
    public IActionResult Index()
    {
        return View();
    }

    //signout

    public IActionResult SignOut()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Login",new{area="client"});
    }

  
}
