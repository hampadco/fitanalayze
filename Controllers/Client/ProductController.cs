using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.Client;


public class ProductController  : BaseController
{
    

   

    public IActionResult listProduct()
    {
        return View();
    }

    public IActionResult details(int id)
    {
        return View();
    }

      public IActionResult cart()
    {
        return View();
    }

    
}
