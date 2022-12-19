using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class UserContext : DbContext
{

    public UserContext(DbContextOptions<UserContext> options) : base(options){

    }

    public DbSet<Designer> Designers { get; set; }
    public DbSet<Design> Designs {set; get;}

}



