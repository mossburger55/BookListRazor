using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        //constructor is required for dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //set property to make an entry point 
        public DbSet<Books> Book { get; set; }
    }
}

//In Entity Framework Core, the DbSet represents the set of entities. In a database, 
//a group of similar entities is called an Entity Set. The DbSet enables the user to 
//perform various operations like add, remove, update, etc. on the entity set.
