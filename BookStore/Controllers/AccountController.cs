using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            // Sprawdzenie, czy użytkownik jest administratorem
            var adminUser = _context.Administrators.FirstOrDefault(a => a.Username == user.Username && a.Password == user.Password);

            if (adminUser != null)
            {
                // Ustawienie sesji dla administratora
                HttpContext.Session.SetString("Username", adminUser.Username);
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Index", "Home");
            }

            // Logika logowania dla zwykłych użytkowników
            var foundUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (foundUser != null)
            {
                HttpContext.Session.SetString("Username", foundUser.Username);
                HttpContext.Session.Remove("IsAdmin"); // Usuń informację o adminie, jeśli jest ustawiona
                return RedirectToAction("Index", "Home");
            }
            else
            {
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
            if (!IsUserValid(user))
            {
                ViewBag.RegisterError = "Invalid user data";
                return View();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ManageUsers()
        {
            // Pobierz listę użytkowników z bazy danych i przekaż ją do widoku
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            // Znajdź użytkownika do usunięcia na podstawie przekazanego identyfikatora
            var userToDelete = _context.Users.Find(userId);

            if (userToDelete != null)
            {
                // Usuń użytkownika z bazy danych
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }

            // Przekieruj użytkownika z powrotem na stronę zarządzania użytkownikami
            return RedirectToAction("ManageUsers");
        }

        private bool IsUserValid(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            return true;
        }
    }
}
