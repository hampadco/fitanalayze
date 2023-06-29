using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.Client;

public class CoachController : BaseController
{
    

   

    public IActionResult listcoach()
    {
        return View();
    }

    public IActionResult details(int id)
    {
        return View();
    }

      public IActionResult Forget()
    {
        return View();
    }

    
}
