using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        // Zakładamy, że mamy dostęp do jakiegoś prostego źródła danych, ale będziemy używać listy jako przykładu
        private static List<User> registeredUsers = new List<User>();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            // Prosta logika weryfikacji - należy ją rozszerzyć o prawdziwą weryfikację z użyciem bazy danych
            var foundUser = registeredUsers.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (foundUser != null)
            {
                // Użytkownik zalogowany poprawnie
                // Tutaj należy dodać logikę zarządzania sesją
                // Na przykład: HttpContext.Session.SetString("UserId", foundUser.Id);
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

            // Dodajemy użytkownika do listy zarejestrowanych (zamiast do bazy danych)
            registeredUsers.Add(user);
            // Tutaj należy dodać logikę zapisu do bazy danych

            return RedirectToAction("Login");
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

