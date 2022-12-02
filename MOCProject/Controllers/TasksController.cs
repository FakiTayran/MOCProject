using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOCProject.Data;
using MOCProject.Models;
using MOCProject.Utility;

namespace MOCProject.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public TasksController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tasks.Where(x=>x.RelatedUserId == userManager.GetUserId(new System.Security.Claims.ClaimsPrincipal(User.Identity))).Include(t => t.Moc).Include(t => t.RelatedUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Moc)
                .Include(t => t.RelatedUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["MocId"] = new SelectList(_context.Mocs.Where(x=>x.CreatorId == userManager.GetUserId(new System.Security.Claims.ClaimsPrincipal(User.Identity))), "Id", "Definition");
            ViewData["RelatedUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }
        public IActionResult CreateByMocId(int Id)
        {
            List<Moc> moclist = new List<Moc>();
            Moc moc = _context.Mocs.FirstOrDefault(x => x.Id == Id);
            moclist.Add(moc);
            ViewData["IncomingMocId"] = Id;
            ViewData["MocId"] = new SelectList(moclist, "Id", "Definition",Id);
            ViewData["RelatedUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View("Create");
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MocId,RelatedUserId,Duedate,ClosingDate,Comment,Definition,Id")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                Moc moc = _context.Mocs.FirstOrDefault(x => x.Id == task.MocId);
                task.Moc = moc;
                ApplicationUser applicationUser = _context.Users.FirstOrDefault(x => x.Id == task.RelatedUserId);
                task.RelatedUser = applicationUser;
                await _context.SaveChangesAsync();
                var subject = "Size " + task.Moc.Name + " için" + " yeni görev açıldı";
                List<string> mailList = new List<string>();
                var to = task.RelatedUser.Email;
                mailList.Add(to);
                var body = task.Definition;
                MailHelper.MailSender(subject, mailList, body, MailPriority.High);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MocId"] = new SelectList(_context.Mocs, "Id", "Definition", task.MocId);
            ViewData["RelatedUserId"] = new SelectList(_context.Users, "Id", "Id", task.RelatedUserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["MocId"] = new SelectList(_context.Mocs, "Id", "Definition", task.MocId);
            ViewData["RelatedUserId"] = new SelectList(_context.Users, "Id", "Id", task.RelatedUserId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MocId,RelatedUserId,Duedate,ClosingDate,Comment,Definition,Id,ClosingNote")] Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(task.ClosingDate.ToString()))
            {
                ModelState.AddModelError("ClosingDate", "Bir Kapanış Tarihi Eklemelisiniz");
            }
            if (!string.IsNullOrEmpty(task.ClosingDate.ToString()) && string.IsNullOrEmpty(task.ClosingNote))
            {
                ModelState.AddModelError("ClosingNote", "Bir Kapanış Notu Eklemelisiniz");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            ViewData["MocId"] = new SelectList(_context.Mocs, "Id", "Definition", task.MocId);
            ViewData["RelatedUserId"] = new SelectList(_context.Users, "Id", "Id", task.RelatedUserId);
            return View(task);
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
