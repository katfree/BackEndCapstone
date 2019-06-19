using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEndCapstone.Models;
using BackEndCapstone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackEndCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext ctx,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var attendees = _context.PartyAttendee.Include(w => w.WatchParty).Where(pa => pa.UserId == currentUser.Id);
            var watchparty = _context.WatchParty.Include(u => u.User).Include(t => t.Team);

            foreach (var x in attendees)
            {
                if (x.UserId == currentUser.Id )
                {
                    ViewData["imAttending"] = x;
                }
            }

            return View(watchparty);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
