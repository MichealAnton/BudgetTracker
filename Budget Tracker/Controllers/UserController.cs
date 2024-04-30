using Budget_Tracker.Data;
using Budget_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Budget_Tracker.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment;

        public UserController(ApplicationDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user , IFormFile User_Pic_File)
        {
            ModelState.Remove("User_Pic");
            ModelState.Remove("User_Pic_File");
            if (ModelState.IsValid)
            {
                // Hash the password using bcrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.User_Passowrd);
                string hashedConfirmPassword = BCrypt.Net.BCrypt.HashPassword(user.ConfirmPassword);

                // Replace the plain-text password with the hashed password
                user.User_Passowrd = hashedPassword;
                user.ConfirmPassword = hashedConfirmPassword;
                if (User_Pic_File != null && User_Pic_File.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + User_Pic_File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        User_Pic_File.CopyTo(fileStream);
                    }

                    // Set the User_Pic property in the model to the file path or other identifier
                    user.User_Pic = filePath;
                }
                else
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images") + "\\ProfilePicture.jpeg";
                    // If no picture is uploaded, set a default profile picture path
                    user.User_Pic = uploadsFolder;
                }
                if (user.User_Pic.EndsWith(".jpg") || user.User_Pic.EndsWith(".jpeg") || user.User_Pic.EndsWith(".png"))
                {

                }
                else
                {
                    ModelState.AddModelError("User_Pic", "Please upload a valid image file.");
                    return View(user);
                }
                var val_email = _context.Usres.FirstOrDefault(a => a.User_Email == user.User_Email);
                if(val_email == null)
                {
                    
                }
                else
                {
                    ModelState.AddModelError("User_Email", "This Email is aleardy excisted");
                    return View(user);
                }
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
        public IActionResult Login(CheckLogin user )
        {
            if (ModelState.IsValid)
            {
                var authenticatedUser = _context.Usres.FirstOrDefault(u => u.User_Email == user.Email);
                if (authenticatedUser != null)
                {
                    // Verify the hashed password
                    if (BCrypt.Net.BCrypt.Verify(user.Password, authenticatedUser.User_Passowrd))
                    {
                        TempData["Pic"] = authenticatedUser.User_Pic;
                        // Passwords match, user authenticated, redirect to dashboard or home page
                        return RedirectToAction("Index2", "Home");
                    }
                }

                // User not found or invalid credentials, add an error message
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
            }
            // ModelState is invalid, return the view with the invalid model
            return View(user);
        }

    }

}
