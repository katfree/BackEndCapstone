using BackEndCapstone.Data;
using BackEndCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext ctx,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationUsers ;
            var users = _context.ApplicationUsers;
            var currentuser = await GetCurrentUserAsync();
            ViewData["CurrentUser"] = currentuser;


            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Edit()
        {
            
            var currentuser = await GetCurrentUserAsync();
            
            
            return View(currentuser);
        }

        // POST: WatchParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagePath")] ApplicationUser user)
        {
            

            if (ModelState.IsValid)
            {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
    }
}
