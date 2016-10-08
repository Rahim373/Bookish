using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookshop.Model
{
    public class BookshopDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookshopDbContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}
