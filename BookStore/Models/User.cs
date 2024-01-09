
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string Confirm_password { get; set; }


    }
}