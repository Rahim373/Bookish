using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Manager;
using Bookshop.Model;
using Bookshop.ViewModel;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Bookshop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {

            ViewBag.Username = User.Identity.Name;
            BookManager manager = new BookManager();
            List<BookGridViewModel> books = manager.GetAllApprovedBooks();
            return View(books.ToPagedList(page?? 1, 12));
        }


        [Authorize]
        public ActionResult Delete(int id)
        {
            BookManager manager = new BookManager();
            bool deleteBook = manager.DeleteBook(id, User.Identity.GetUserId());
            return Redirect(Request.UrlReferrer?.ToString());
        }

        [Authorize]
        public ActionResult Detail(int id)
        {
            BookManager manager = new BookManager();
            BookDetailViewModel bookDetailViewModel = manager.GetSingleBookDetail(id);
            return View(bookDetailViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}