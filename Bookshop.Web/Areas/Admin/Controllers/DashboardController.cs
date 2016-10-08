using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bookshop.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Account()
        {
            return View();
        }

        // GET: Admin/Dashboard
        public ActionResult Members()
        {
            return View();
        }


    }
}
