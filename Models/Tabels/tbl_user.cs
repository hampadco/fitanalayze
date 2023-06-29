using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class tbl_user
{

    [Key]
    public int Id { get; set; }
    public string Type { get; set; }
    
    
    public string Name { get; set; }

    public string Family { get; set; }

    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
   
   //create image string type can is null
    [AllowNull]
   public string Image { get; set; }






    
       
    
}