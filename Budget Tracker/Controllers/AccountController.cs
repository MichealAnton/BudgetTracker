using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget_Tracker.Models;
using Budget_Tracker.Data;
using System.Runtime.ConstrainedExecution;
namespace Budget_Tracker.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationDBcontext db;
        public AccountController(ApplicationDBcontext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Account> accounts = db.Accounts.ToList();
            return View(accounts);
        }
        public IActionResult Insert(double initialBudget, string name)
        {
            Account acc = new Account();
            acc.Account_Name = name;
            acc.Initial_Budget = initialBudget;
            db.Accounts.Add(acc);
            db.SaveChanges();
            return Redirect("Index");

        }
        public IActionResult Search(int id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
        public IActionResult Delete(int id)
        {
            Account acc = db.Accounts.FirstOrDefault(c => c.Account_Id == id);
            db.Accounts.Remove(acc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult edit(Account acc)
        {
           // Account acc = db.Accounts.FirstOrDefault(c => c.Account_Id == id);
            if (ModelState.IsValid)
            {
                           db.Accounts.Update(acc);
                           db.SaveChanges();
                TempData["AlertMessage"] = "Account Updated!";
                return RedirectToAction("Index");
            }
            return View(acc);


        }
        public IActionResult Create()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            var urid = db.Usres.FirstOrDefault(u => u.User_ID == (int)TempData["UserId"]);
            account.User_Id = urid.User_ID;
            ModelState.Remove("User"); 
            if (ModelState.IsValid)
            {
                // Get the current logged-in user (replace with your logic)
                // Check for duplicate account names for the same user (optional)
                if (db.Accounts.Any(a => a.User_Id == urid.User_ID ))
                {
                    ModelState.AddModelError("Name", "An account with this name already exists.");
                    return View(account);
                }

                db.Accounts.Add(account);
                db.SaveChanges();

                return RedirectToAction("Index"); // Redirect to account list or success page
            }
            return View(account);
        }
        public IActionResult Detail(int id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
    }
}
