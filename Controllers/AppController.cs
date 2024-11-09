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
        public async Task<IActionResult> Index(int Id)
        {
            //Get the user to send
            var User = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            return View(User);
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
                    return RedirectToAction("Index",new { Id = checkUser.Id });
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
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Id,username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                //Check if the user exists in the database alread
                var checkUser = await _context.Users.FirstOrDefaultAsync(u=>u.username==user.username);

                //If user does not exist, add them to the database
                if (checkUser == null)
                {
                    //Add the user to the database
                    _context.Users.Add(user);
                    //Save the changes
                    await _context.SaveChangesAsync();
                    //Redirect user to the index page
                    return RedirectToAction("Index", new { Id = user.Id });
                }

                //If the user exists, raise an error and tell them that the user already exists
                TempData["Message"] = "User already exists!";
                ModelState.AddModelError("", "User with the username already exists!");
            }

            //If not valid, just display the view
            return View(user);
        }

        //Get method to get the water logging webpage
        public async Task<IActionResult> Water(int Id) 
        {
            //Get the user associated with the Id
            var User = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            return View(User); 
        }

        //Post method to allow the user to log 

        //Get method to get the water logging webpage
        public async Task<IActionResult> Sleep(int Id)
        {
            //Get the user associated with the Id
            var User = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            return View(User);
        }
    }
}
