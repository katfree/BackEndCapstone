using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Data;
using BackEndCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using BackEndCapstone.Models.WatchPartyViewModels;
using System.IO;

namespace BackEndCapstone.Controllers
{
    public class WatchPartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
       
        public WatchPartiesController(ApplicationDbContext ctx,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = ctx;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        


        // GET: WatchParties
        public async Task<IActionResult> Index(string SelectedTeam, IndexViewModel watchParty)
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "Name", "Name");
            if (SelectedTeam != null)
            {
                watchParty.WatchParties = _context.WatchParty
                    .Include(w => w.User)
                    .Include(t => t.Team)
                    .Where(tt => tt.Team.Name == SelectedTeam)
                    .OrderByDescending(p => p.Date);
                return View(watchParty);
            }
            else
            {
                watchParty.WatchParties = _context.WatchParty.Include(w => w.User).Include(t => t.Team);
                return View(watchParty);
            }
        }

        // GET: WatchParties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: WatchParties/Create
        public IActionResult Create()
        {
            UploadWatchPartyPicViewModel viewModel = new UploadWatchPartyPicViewModel();
            viewModel.watchParty = new WatchParty();
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "Name");
            
            return View(viewModel);
        }

        // POST: WatchParties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UploadWatchPartyPicViewModel viewModel)
        {
            ModelState.Remove("watchParty.UserId");

            // adding current userId
            var user = await GetCurrentUserAsync();
            viewModel.watchParty.UserId = user.Id;


            if (ModelState.IsValid)
            {
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
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images/partypic", fileName);
                    //var filePath = Path.GetTempFileName();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(stream);
                        // validate file, then move to CDN or public folder
                    }

                    viewModel.watchParty.ImagePath = viewModel.ImageFile.FileName;
                }




                _context.Add(viewModel.watchParty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "Name", viewModel.watchParty.TeamId);

            return View(viewModel.watchParty);
        }

        // GET: WatchParties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchParty = await _context.WatchParty.FindAsync(id);
            if (watchParty == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", watchParty.UserId);
            return View(watchParty);
        }

        // POST: WatchParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WatchPartyId,Title,Description,Address,Limit,Date,UserId,ImagePath,TeamId")] WatchParty watchParty)
        {
            if (id != watchParty.WatchPartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchParty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchPartyExists(watchParty.WatchPartyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", watchParty.UserId);
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
            _context.WatchParty.Remove(watchParty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchPartyExists(int id)
        {
            return _context.WatchParty.Any(e => e.WatchPartyId == id);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AttendWatchParty( int WatchPartyId)
        {
            

           PartyAttendee partyAttendee = new PartyAttendee();
            var user = await GetCurrentUserAsync();
            var watchParty = _context.WatchParty.Where(p => p.WatchPartyId == WatchPartyId ).Include(p => p.PartyAttendees).FirstOrDefault();
            var attendees = watchParty.PartyAttendees.Select(s => s.UserId);
           var id = WatchPartyId;
            var msg = "You are already going!";


                if (attendees.Contains(user.Id)) {
                 ViewBag.Message = msg;
                return RedirectToAction("Details", new { id = id });
            } 
                else
                {
                    partyAttendee.UserId = user.Id;
                    partyAttendee.WatchPartyId = watchParty.WatchPartyId;

                    
                        watchParty.Limit = watchParty.Limit - 1;
                        _context.Add(partyAttendee);
                        await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                

                }

            





        }
    }
}
