using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bookshop.Model;
using Bookshop.ViewModel;

namespace Bookshop.Manager
{
    public class BookManager
    {
        private BookshopDbContext db;

        public BookManager()
        {
            db = new BookshopDbContext();
        }

        public List<BookDetailViewModel> GetAllBookByUser(string userId)
        {
            List<Book> books = db.Books.Where(x => x.UserId == userId).ToList();
            List<BookDetailViewModel> bookList = new List<BookDetailViewModel>();
            foreach (Book book in books)
            {
                IQueryable<Photo> photo = from p in db.Photos
                                          where p.Book.Id == book.Id
                                          select p;

                List<Photo> photos = photo.ToList();

                List<Department> departments = book.Departments.ToList();
                Department department = db.Departments.Find(departments[0].Id);

                string date = String.Format("{0:d MMM, yyyy}", book.UploadDateTime);
                Condition condition = db.Conditions.Find(book.Condition.Id);

                Category category = db.Categories.Find(book.Category.Id);


                BookDetailViewModel bookDetail = new BookDetailViewModel()
                {
                    Author = book.Author,
                    Photo = photos[0].Path,
                    Price = book.Price,
                    Title = book.Title,
                    Id = book.Id,
                    UploadDateTime = date,
                    Condition = condition.Name,
                    Department = department.Name,
                    Category = category.Name,
                    AdditionalInfo = book.AdditionalInfo,
                    Edition = Utils.getEdition(book.Edition),
                    ContactNo = book.ApplicationUser.PhoneNumber,
                    Email = book.ApplicationUser.Email
                };

                bookList.Add(bookDetail);
            }
            return bookList;
        }

        public List<BookGridViewModel> GetAllApprovedBooks()
        {
            List<Book> books = db.Books.Where(x=>x.Approved == true).ToList();
            List<BookGridViewModel> bookGridList = new List<BookGridViewModel>();
            foreach (Book book in books)
            {
                IQueryable<Photo> photo = from p in db.Photos
                    where p.Book.Id == book.Id
                    select p;

                List<Photo> photos = photo.ToList();

                List<Department> departments = book.Departments.ToList();
                Department department = db.Departments.Find(departments[0].Id);
                string date = String.Format("{0:d MMM, yyyy}", book.UploadDateTime);

                BookGridViewModel bookGrid = new BookGridViewModel()
                {
                    Author = book.Author,
                    Photo = photos[0].Path,
                    Price = book.Price,
                    Title = book.Title,
                    Id = book.Id,
                    UploadDateTime = date
                };
                bookGridList.Add(bookGrid);
            }
            return bookGridList;
        }

        public BookDetailViewModel GetSingleBookDetail(int bookId)
        {
            Book book = db.Books.Find(bookId);

            IQueryable<Photo> photo = from p in db.Photos
                                      where p.Book.Id == book.Id
                                      select p;

            List<Photo> photos = photo.ToList();

            List<Department> departments = book.Departments.ToList();
            Department department = db.Departments.Find(departments[0].Id);

            string date = String.Format("{0:d MMM, yyyy}", book.UploadDateTime);
            Condition condition = db.Conditions.Find(book.Condition.Id);

            Category category = db.Categories.Find(book.Category.Id);


            BookDetailViewModel bookDetail = new BookDetailViewModel()
            {
                Author = book.Author,
                Photo = photos[0].Path,
                Price = book.Price,
                Title = book.Title,
                Id = book.Id,
                UploadDateTime = date,
                Condition = condition.Name,
                Department = department.Name,
                Category = category.Name,
                AdditionalInfo = book.AdditionalInfo,
                Edition = Utils.getEdition(book.Edition),
                ContactNo = book.ApplicationUser.PhoneNumber,
                Email = book.ApplicationUser.Email
            };

            return bookDetail;
        }

        public bool SaveBook(UploadBookViewModel uploadBook, HttpPostedFileBase file, string userId)
        {
            List<Department> depts = new List<Department>();
            depts.Add(db.Departments.Single(x=>x.Id == uploadBook.Department));
            Category category = db.Categories.Find(uploadBook.Category);
            Condition condition = db.Conditions.Find(uploadBook.Condition);

            Photo p = new Photo();
            if (file != null)
            {
                string pic = file.FileName;
                string path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img/books"), pic);
                file.SaveAs(path);
                p.Path = @"/Content/img/books/" + pic;
            }

            try
            {
                Book latestBook = new Book()
                {
                    UserId = userId,
                    UploadDateTime = DateTime.Now,
                    Title = uploadBook.Title,
                    Price = uploadBook.Price,
                    Edition = uploadBook.Edition,
                    Departments = depts,
                    Category = category,
                    CategoryId = category.Id,
                    Approved = false,
                    Author = uploadBook.Author,
                    ConditionId = uploadBook.Condition,
                    Condition = condition,
                    AdditionalInfo = uploadBook.AdditionalInfo,

                };
                db.Books.Add(latestBook);

                db.SaveChanges();


                p.UserId = userId;
                p.Book = latestBook;
                p.UploadDateTime = DateTime.Now;

                db.Photos.Add(p);

                if (db.SaveChanges() > 0) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        

        public bool DeleteBook(int id, string getUserId)
        {
            Book book = db.Books.Find(id);
            if (book.UserId == getUserId)
            {
                db.Entry(book).State = EntityState.Deleted;
                return true;
            }
            return false;
        }
    }
}
