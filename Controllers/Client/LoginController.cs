using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.Client;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

public class LoginController   : BaseController
{
    private readonly Context _context;
    public LoginController(Context context) 
    {
        _context = context;
    }
    

   

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register( )
    {
           return View();
    }


   [HttpPost]
    public IActionResult Register( tbl_user user)
    {
       //check if exists email
         var userExists = _context.tbl_Users.Any(x => x.Email == user.Email);
        if (userExists)
        {
            TempData["error"] = "ایمیل وارد شده تکراری است";
        }
        else
        {
            //add user
            user.Image="/img/core-img/logo-small.png";
            _context.tbl_Users.Add(user);
            _context.SaveChanges();
            TempData["success"] = "ثبت نام با موفقیت انجام شد";
        }


        return RedirectToAction("Register");
    }

      public IActionResult Forget()
    {
        return View();
    }



    //signin 

    public IActionResult signin(string email,string password)
    {
        //check if exists email
         var userExists = _context.tbl_Users.Any(x => x.Email == email);
        if (userExists)
        {
            //check password
            var user = _context.tbl_Users.Where(x => x.Email == email).FirstOrDefault();
            if(user.Password == password)
            {
                //login use climes

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Type),
                    //User.Id
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //user image
                    new Claim("Image", user.Image),
                    //user phone
                    new Claim("Phone", user.Phone),
                    //user family
                    new Claim("Family", user.Family),

                };
                //return /user/dashboard/index
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return RedirectToAction("Index", "Dashboard", new { area = "User" });
                

               
            }
            else
            {
                TempData["error"] = "رمز عبور اشتباه است";
            }
        }
        else
        {
            TempData["error"] = "ایمیل وارد شده صحیح نیست";
        }
        // TODO: Your code here
        return RedirectToAction("Index");
    }
    

    //ResetPassword

    public IActionResult ResetPassword(string email)
    {

        //check if exists email
         var userExists = _context.tbl_Users.Any(x => x.Email == email);
        if (userExists)
        {
            //send email
            Email.sendmailcode(email,"passwrord : " + _context.tbl_Users.Where(x => x.Email == email).FirstOrDefault().Password );
          
            TempData["success"] = "ایمیل بازیابی رمز عبور ارسال شد";
        }
        else
        {
            TempData["error"] = "ایمیل وارد شده صحیح نیست";
        }
        return RedirectToAction("Forget");
       
    }

    
}
