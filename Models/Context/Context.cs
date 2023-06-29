using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{

     public Context(DbContextOptions<Context> options):base(options)
        {
            
        }   

    public DbSet<tbl_user> tbl_Users { get; set; }




    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(@"Server=.;Database=fitnessDb;Trusted_Connection=True;");
    // }
    
    
}