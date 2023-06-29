using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Controllers.user;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace App.Controllers.user;

public class ProfileController : BaseController
{
    
    private readonly Context _context;
    public ProfileController(Context context) 
    {
        _context = context;
    }
   
    public IActionResult Index()
    {
        return View();
    }

      //addprofile 

    [HttpPost]
    public IActionResult AddProfile(Muser user)
    {

         //get user id
        var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        //get user
        var userDb = _context.tbl_Users.Find(userId);

        //if user.image in not null upload in /img/core-img/
        if (user.File != null)
        {
            //upload file
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(user.File.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/core-img", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                user.File.CopyTo(stream);
            }
            //save image in database
            user.Image = fileName;
           userDb.Image = user.Image;
        }
        
       
        //update user
        userDb.Name = user.Name;
        userDb.Family = user.Family;
        userDb.Phone = user.Phone;
      
        //save change
        _context.SaveChanges();
        //set message
        TempData["success"] = "اطلاعات با موفقیت ثبت شد";

        //update claim first step find claim and not null value update value
        var identity = (ClaimsIdentity)User.Identity;

        // Find the "Phone" claim in the identity
       var phoneClaim = identity.FindFirst("Phone");

        if (phoneClaim != null)
        {
            // If the "Phone" claim exists, update its value
            identity.RemoveClaim(phoneClaim);
            identity.AddClaim(new Claim("Phone", user.Phone));
            
            
        }

        //name
       
        var nameClaim = identity.FindFirst(ClaimTypes.Name);

        if (nameClaim != null)
        {
            // If the "Phone" claim exists, update its value
            identity.RemoveClaim(nameClaim);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            
            
        }

       

        //family
        var familyClaim = identity.FindFirst("Family");

        if (familyClaim != null)
        {
            // If the "Phone" claim exists, update its value
            identity.RemoveClaim(familyClaim);
            identity.AddClaim(new Claim("Family", user.Family));
            
            
        }

        //image
        var imageClaim = identity.FindFirst("Image");

        if (imageClaim != null)
        {
            // If the "Phone" claim exists, update its value
            identity.RemoveClaim(imageClaim);
            identity.AddClaim(new Claim("Image", userDb.Image));
            
            
        }

        //update climes
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));







        //redirect to profile
        return RedirectToAction("Index");
            


       
       
        


       
    }

    

    
}
