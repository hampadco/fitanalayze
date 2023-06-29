using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.user;

namespace App.Controllers.user;

public class MyPlaneController : BaseController
{
    
   
    public IActionResult plane()
    {
        return View();
    }

    public IActionResult Suppelment()
    {
        return View();
    }


public IActionResult DeatilsMovement()
{
  //TODO: Implement Realistic Implementation
  return View();
}


    
}
