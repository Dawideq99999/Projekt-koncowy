using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

public class BookstoreController : Controller
{
    private static IList<Book> books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Title = "Wiedźmin. Miecz przeznaczenia",
            Author = "A.Sapkowski",
            PageCount = 400,
            Isbn = "9788090091252"
        },
        new Book
        {
            Id = 2,
            Title = "Wiedźmin. Ostatnie życzenie",
            Author = "A. Sapkowski",
            PageCount = 332,
            Isbn = "9788078282821"
        },
        new Book
        {
            Id = 3,
            Title = "How to train your dragon",
            Author = "Cowell Cressid",
            PageCount = 214,
            Isbn = "985-0-672-91810-3"
        },
        new Book
        {
            Id = 4,
            Title = "Władca pierścieni. Drużyna pierścienia",
            Author = "J.R.R. Tolkien",
            PageCount = 426,
            Isbn = "978-0-395-19395-7"
        },
        new Book
        {
            Id = 5,
            Title = "Hobbit, czyli tam i z powrotem",
            Author = "J.R.R Tolkien",
            PageCount = 320,
            Isbn = "978-1-85326-120-9"
        }
    };

    private readonly ILogger<BookstoreController> _logger;

    public BookstoreController(ILogger<BookstoreController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(books);
    }

    // GET: FilmController/Details/5
    public ActionResult Details(int id)
    {
        return View(books.FirstOrDefault(book => book.Id == id));
    }

    // GET: FilmController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FilmController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Book book)
    {

        book.Id = books.Count + 1;
        books.Add(book);
        return RedirectToAction("Index");
    }

    // GET: FilmController/Edit/5
    public ActionResult Edit(int id)
    {
        return View(books.FirstOrDefault(book => book.Id == id));
    }

    // POST: FilmController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Book book)
    {
        Book bookToEdit = books.FirstOrDefault(book => book.Id == id);

        bookToEdit.Title = book.Title;
        bookToEdit.Author = book.Author;
        bookToEdit.Isbn = book.Isbn;

        return RedirectToAction("Index");
    }

    // GET: FilmController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(books.FirstOrDefault(book => book.Id == id));
    }

    // POST: FilmController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Book book, int id)
    {
        Book bookToRemove = books.FirstOrDefault(x => x.Id == id);
        books.Remove(bookToRemove);
        return RedirectToAction("Index");
    }


}
