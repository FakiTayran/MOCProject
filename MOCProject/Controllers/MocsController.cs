using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOCProject.Data;
using MOCProject.Models;
using MOCProject.ModelViews;
using MOCProject.Utility;
using MOCProject.ViewModels;

namespace MOCProject.Controllers
{
    [Authorize]
    public class MocsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public MocsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Mocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mocs.ToListAsync());
        }

        // GET: Mocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moc = await _context.Mocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moc == null)
            {
                return NotFound();
            }
            return View(moc);
        }

        // GET: Mocs/Create
        public IActionResult Create()
        {
            var viewModel = new MocCreateViewModel();
            viewModel.Departments = _context.Departments.Include(x => x.DepartmentMembers).ToList();
            if (viewModel.Departments.Count > 0)
            {
                return View(viewModel);
            }
            return View();
        }

        // POST: Mocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Moc moc)
        {
            var stringOfDepartments = moc.RelatedDepartments.Select(x => x.Id).ToString();
            List<Department> Departments = new List<Department>();
            List<ApplicationUser> Users = new List<ApplicationUser>();
            foreach (int Id in moc.RelatedDepartments.Select(x => x.Id))
            {
                var department = _context.Departments.FirstOrDefault(x => x.Id == Id);
                Departments.Add(department);
            }
            foreach (string Id in moc.RelatedUsers.Select(x => x.Id))
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == Id);
                Users.Add(user);
            }
            moc.RelatedDepartments = Departments;
            moc.RelatedUsers = Users;
            moc.CreatorId = userManager.GetUserId(new ClaimsPrincipal(User.Identity));

            _context.Add(moc);
            await _context.SaveChangesAsync();
            var response = new { success = true, responseText = "success" };
            var subject = moc.Name + " adında " + " sizin ve departmanınızın dahil olduğu bir MOC açıldı";
            var from = moc;
            var to = moc.RelatedUsers.Select(x => x.Email).ToList();
            var body = moc.Definition;
            MailHelper.MailSender(subject, to, body, MailPriority.High);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response), "application/json");

        }

        // GET: Mocs/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moc = await _context.Mocs.FindAsync(id);
            MocEditViewModel mocEditViewModel = new MocEditViewModel();
            mocEditViewModel.Id = moc.Id;
            if (moc == null)
            {
                return NotFound();
            }
            return View(mocEditViewModel);
        }

        // POST: Mocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MocEditViewModel mocEditViewModel)
        {
            if (id != mocEditViewModel.Id)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(mocEditViewModel.ClosingDate.ToString()))
            {
                ModelState.AddModelError("ClosingDate", "Lütfen Moc için bir kapanış tarihi giriniz");

            }
            if (_context.Tasks.Where(x => x.MocId == id).Any(x => string.IsNullOrEmpty(x.ClosingNote)))
            {
                var notClosedTask = _context.Tasks.Where(x => x.MocId == id & string.IsNullOrEmpty(x.ClosingNote)).ToList();
                var thisTasksUsers = notClosedTask.Select(x => x.RelatedUserId);
                ModelState.AddModelError("ClosingDate", "Bu Moc için atanan taskların tamamı kapatılmamış lütfen bu taskların kapanması için ilgili departman kullanıcılarıyla iletişime geçiniz Tam Liste Aşağıdadır");
                string liste = "";
                for (int i = 0; i < thisTasksUsers.ToList().Count(); i++)
                {
                    liste += $"{i + 1} -) {_context.Users.FirstOrDefault(x => x.Id == thisTasksUsers.ToList()[i]).UserName}" + System.Environment.NewLine;
                }
                ModelState.AddModelError("Id", liste);
            }


            try
            {
                if (ModelState.IsValid)
                {
                    Moc dbMoc = _context.Mocs.Include(x => x.RelatedDepartments).Include(x => x.RelatedUsers).FirstOrDefault(x => x.Id == id);
                    dbMoc.ClosingDate = mocEditViewModel.ClosingDate;

                    _context.Update(dbMoc);
                    _context.Entry(dbMoc).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MocExists(mocEditViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(mocEditViewModel);
        }
        private bool MocExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
