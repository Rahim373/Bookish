using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Manager;
using Bookshop.Model;
using Bookshop.ViewModel;
using Microsoft.AspNet.Identity;

namespace Bookshop.Web.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class DashboardController : Controller
    {
        
        // GET: User/Dashboard
        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Uploaded()
        {
            BookManager manager = new BookManager();
            List<BookDetailViewModel> bookGridViewModels = manager.GetAllBookByUser(User.Identity.GetUserId());
            return View(bookGridViewModels);
        }


        [HttpGet]
        public ActionResult Upload()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            ConditionManager conditionManager = new ConditionManager();
            ViewBag.Conditions = conditionManager.GetConditions();
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Upload(UploadBookViewModel uploadBook, HttpPostedFileBase file)
        {

            DepartmentManager departmentManager = new DepartmentManager();
            ConditionManager conditionManager = new ConditionManager();
            ViewBag.Conditions = conditionManager.GetConditions();
            ViewBag.Departments = departmentManager.GetAllDepartments();

            if (ModelState.IsValid)
            {
                BookManager bookManager = new BookManager();
                bool saved = bookManager.SaveBook(uploadBook, file, User.Identity.GetUserId());
                if (saved) return RedirectToAction("Uploaded", "Dashboard");
                else return View(uploadBook);
            }
            return View(uploadBook);
        }
    }
}
