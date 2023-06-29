using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.Client;

public class PadcastController  : BaseController
{
    

   

    public IActionResult index()
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
