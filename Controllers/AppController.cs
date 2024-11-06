using Microsoft.AspNetCore.Mvc;
using WellNote.Data;
using WellNote.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var Users = await _context.Users.ToListAsync();

            return View(Users);
        }
    }
}
