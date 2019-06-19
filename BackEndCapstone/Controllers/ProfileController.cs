using BackEndCapstone.Data;
using BackEndCapstone.Models;
using BackEndCapstone.Models.RegistrationViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            viewModel.watchParty = _context.WatchParty.Include(u => u.User).Include(p => p.PartyAttendees).Include(t => t.Team);
            var currentuser = await GetCurrentUserAsync();
            ViewData["CurrentUser"] = currentuser;


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UploadProfilePicViewModel viewModel)
        {
            var currentuser = await GetCurrentUserAsync();
            var User = await _context.ApplicationUsers.FindAsync(currentuser.Id);

            ModelState.Remove("viewModel.Id");

                if (viewModel.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewModel.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images/userprofilepic", fileName);
                   
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(stream);
                    }

                    User.ImagePath = viewModel.ImageFile.FileName;
                }


                _context.Update(User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> EditWatchParty(int? id)
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var watchParty = await _context.WatchParty
                .Include(w => w.User)
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.WatchPartyId == id);
            if (watchParty == null)
            {
                return NotFound();
            }
            
            return View(watchParty);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWatchParty(int id, [Bind("WatchPartyId,Title,Description,Address,Limit,Date,UserId,ImagePath,TeamId")] WatchParty watchParty)
        {
            
            if (id != watchParty.WatchPartyId)
            {
                return NotFound();
            }
            ModelState.Remove("UserId");

            var currentuser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                watchParty.UserId = currentuser.Id;

                    _context.Update(watchParty);
                    await _context.SaveChangesAsync();
                
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(watchParty);
        }

        // GET: WatchParties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchParty = await _context.WatchParty
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WatchPartyId == id);
            if (watchParty == null)
            {
                return NotFound();
            }

            return View(watchParty);
        }

        // POST: WatchParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watchParty = await _context.WatchParty.FindAsync(id);
            var attendees = _context.PartyAttendee.Where(pa => pa.WatchPartyId == id);

            foreach (var x in attendees)
            {
              _context.PartyAttendee.Remove(x);
            }
            
            _context.WatchParty.Remove(watchParty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
