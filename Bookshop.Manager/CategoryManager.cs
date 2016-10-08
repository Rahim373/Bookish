using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Model;

namespace Bookshop.Manager
{
    public class CategoryManager
    {
        BookshopDbContext db;

        public CategoryManager()
        {
            db = new BookshopDbContext();
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<Category> GetCategoriesByDepartmentId(int id)
        {
            

            var q = from category in db.Categories
                where category.Departments.Any(c => c.Id == id)
                select category;
            List<Category> categories = q.ToList();
            return categories;
        }
    }
}
