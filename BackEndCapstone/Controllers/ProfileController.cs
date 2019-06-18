using BackEndCapstone.Data;
using BackEndCapstone.Models;
using BackEndCapstone.Models.RegistrationViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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


        public async Task<IActionResult> Index(UploadProfilePicViewModel viewModel)
        {
            viewModel.IUsers = _context.ApplicationUsers.Include(w => w.WatchParties).Include(p => p.PartyAttendees) ;
            viewModel.watchParty = _context.WatchParty.Include(u => u.User).Include(p => p.PartyAttendees);
            var currentuser = await GetCurrentUserAsync();
            ViewData["CurrentUser"] = currentuser;


            return View(viewModel);
        }

        //public async Task<IActionResult> Edit()
        //{
            
        //    var currentuser = await GetCurrentUserAsync();
            
            
        //    return View(currentuser);
        //}

        // POST: WatchParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UploadProfilePicViewModel viewModel)
        {
            var currentuser = await GetCurrentUserAsync();
            var User = await _context.ApplicationUsers.FindAsync(currentuser.Id);

            ModelState.Remove("viewModel.Id");

                if (viewModel.ImageFile != null)
                {
                    // don't rely on or trust the FileName property without validation
                    //**Warning**: The following code uses `GetTempFileName`, which throws
                    // an `IOException` if more than 65535 files are created without 
                    // deleting previous temporary files. A real app should either delete
                    // temporary files or use `GetTempPath` and `GetRandomFileName` 
                    // to create temporary file names.
                    var fileName = Path.GetFileName(viewModel.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images/userprofilepic", fileName);
                    //var filePath = Path.GetTempFileName();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(stream);
                        // validate file, then move to CDN or public folder
                    }

                    User.ImagePath = viewModel.ImageFile.FileName;
                }


                _context.Update(User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
    }
}
