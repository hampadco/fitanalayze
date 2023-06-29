using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.user;

namespace App.Controllers.user;

public class TicketsController : BaseController
{
    
   
    public IActionResult index()
    {
        return View();
    }

    


    
}
