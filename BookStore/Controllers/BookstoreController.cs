using Bookstore.Models;
using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Controllers
{
    public class BookstoreController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public BookstoreController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
            var booksInDb = _bookDbContext.Books.ToList();
            return View(booksInDb);
        }

        // GET: Bookstore/Details/5
        public ActionResult Details(int id)
        {
            var book = _bookDbContext.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // GET: Bookstore/Create
        public ActionResult Create()
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            return View();
        }

        // POST: Bookstore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookRequest book)
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Title = book.Title,
                    Author = book.Author,
                    PageCount = book.PageCount,
                    Isbn = book.Isbn
                };

                _bookDbContext.Books.Add(newBook);
                _bookDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Bookstore/Edit/5
        public ActionResult Edit(int id)
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            var book = _bookDbContext.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // POST: Bookstore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookRequest book)
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            var bookToEdit = _bookDbContext.Books.FirstOrDefault(b => b.Id == id);

            if (bookToEdit != null)
            {
                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.PageCount = book.PageCount;
                bookToEdit.Isbn = book.Isbn;

                _bookDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Bookstore/Delete/5
        public ActionResult Delete(int id)
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            var book = _bookDbContext.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // POST: Bookstore/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Sprawdź, czy użytkownik jest administratorem
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return Unauthorized(); // Lub przekierowanie do strony logowania
            }

            var bookToRemove = _bookDbContext.Books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _bookDbContext.Books.Remove(bookToRemove);
                _bookDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
