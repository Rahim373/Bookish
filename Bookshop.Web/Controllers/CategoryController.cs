using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Manager;
using Bookshop.Model;

namespace Bookshop.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Authorize]
        [HttpPost]
        public ActionResult CategoryByDeptId(int id)
        {
            CategoryManager categoryManager = new CategoryManager();
            List<Category> categoriesByDepartmentId = categoryManager.GetCategoriesByDepartmentId(id);
            return Json(categoriesByDepartmentId);
        }
    }
}
