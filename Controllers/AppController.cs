using Microsoft.AspNetCore.Mvc;
using WellNote.Data;
using WellNote.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WellNote.Controllers
{
    public class AppController : Controller
    {
        //Store the context
        private readonly WellNoteContext _context;

        //A constructor to load the context
        public AppController(WellNoteContext context)
        {
            _context = context;
        }

        //Index method to print the index view
        public IActionResult Index()
        {
            return View();
        }

        //Get method which allows the user to login
        public IActionResult Login()
        {
            return View();
        }

        //Post method which logs the user in
        [HttpPost]
        public async Task<IActionResult> Login([Bind("username,password")]User user)
        {
            if (ModelState.IsValid)
            {
                //Query the database to check if the user exists
                var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.username == user.username && u.password == user.password);

                //If user found
                if (user != null)
                {
                    TempData["Message"] = "Login successful!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }

            }

            return View(user);
        }

        //Get method which allows the user to register
        public IActionResult Register()
        {
            return View();
        }

        //Post method which allows the user to register
        
    }
}
