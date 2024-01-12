using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Dodaj using Microsoft.AspNetCore.Http
using System.Linq;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookDbContext _context;

        public AccountController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            // Prosta logika weryfikacji - należy ją rozszerzyć o prawdziwą weryfikację z użyciem bazy danych
            var foundUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (foundUser != null)
            {
                // Użytkownik zalogowany poprawnie
                // Ustaw dane sesji
                HttpContext.Session.SetString("Username", foundUser.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Błędne dane logowania
                ViewBag.LoginError = "Invalid username or password";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            // Prosta logika rejestracji - należy ją rozszerzyć o prawdziwą obsługę bazy danych
            // Tutaj można dodać logikę walidacji danych użytkownika przed rejestracją

            // Przykład walidacji:
            if (!IsUserValid(user))
            {
                ViewBag.RegisterError = "Invalid user data";
                return View();
            }

            // Dodajemy użytkownika do bazy danych
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            // Czyść dane sesji
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private bool IsUserValid(User user)
        {
            // Przykładowa walidacja danych użytkownika
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            // Tutaj można dodać inne reguły walidacji, np. sprawdzenie, czy użytkownik o podanej nazwie już istnieje w bazie danych

            return true;
        }
    }
}
