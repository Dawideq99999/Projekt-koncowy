using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            

            var books = GetBooksFromDatabase();

            
            return View(books);
        }

        private List<Book> GetBooksFromDatabase()
        {
            // Tutaj można dodać kod do pobierania książek z bazy danych
            // Na potrzeby przykładu, tworzymy pustą listę książek
            var books = new List<Book>();

            // Tutaj dodajemy przykładowe książki do listy
            books.Add(new Book { Title = "Książka 1", Author = "Autor 1" });
            books.Add(new Book { Title = "Książka 2", Author = "Autor 2" });
            books.Add(new Book { Title = "Książka 3", Author = "Autor 3" });

            return books;
        }
    }
}
