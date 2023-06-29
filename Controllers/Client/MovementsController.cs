using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.Client;

public class MovementsController  : BaseController
{
    

   

    public IActionResult Category()
    {
        return View();
    }

    public IActionResult details(int id)
    {
        return View();
    }

      public IActionResult ListMovement()
    {
        return View();
    }

    
}
