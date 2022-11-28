using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOCProject.Data;
using MOCProject.Models;

namespace MOCProject.Controllers
{
    public class MocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MocsController(ApplicationDbContext context)
        {
            _context = context;
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
            return View();
        }

        // POST: Mocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Definition,Justification,Benefit,ClosingDate,Id")] Moc moc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moc);
        }

        // GET: Mocs/Edit/5
    }
}
