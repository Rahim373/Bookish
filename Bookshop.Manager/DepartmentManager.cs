using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Model;

namespace Bookshop.Manager
{
    public class DepartmentManager
    {
        private BookshopDbContext db;

        public DepartmentManager()
        {
            db = new BookshopDbContext();
        }

        public List<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }
    }
}
