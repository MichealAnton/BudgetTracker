using Budget_Tracker.Data;
using Budget_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Budget_Tracker.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public UserController(ApplicationDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password using bcrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.User_Passowrd);
                string hashedConfirmPassword = BCrypt.Net.BCrypt.HashPassword(user.ConfirmPassword);

                // Replace the plain-text password with the hashed password
                user.User_Passowrd = hashedPassword;
                user.ConfirmPassword = hashedConfirmPassword;
                _context.Usres.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var authenticatedUser = _context.Usres.FirstOrDefault(u => u.User_Email == user.User_Email && u.User_Passowrd == user.User_Passowrd);
                if (authenticatedUser != null)
                {
                    // Verify the hashed password
                    if (BCrypt.Net.BCrypt.Verify(user.User_Passowrd, authenticatedUser.User_Passowrd))
                    {
                        // Passwords match, user authenticated, redirect to dashboard or home page
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
                else
                {
                    // User not found or invalid credentials, add an error message
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return View(user);
                }
            }
            // ModelState is invalid, return the view with the invalid model
            return View(user);
        }
    }

}
