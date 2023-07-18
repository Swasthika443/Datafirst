using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DFA_KT.Models;
using Microsoft.Data.SqlClient;

namespace DFA_KT.Controllers
{
    public class TraineesController : Controller
    {
        private readonly CoreMvcContext _context;

        public TraineesController(CoreMvcContext context)
        {
            _context = context;
        }

        // GET: Trainees
        public async Task<IActionResult> Index(string sortorder)
        {
            //using (var context = new CoreMvcContext())
           // {

                //    var data = context.Trainees.OrderBy(s => s.Name).ToList();
                //  

                var trainees = _context.Trainees.AsQueryable();
                ViewData["NameOrder"] = String.IsNullOrEmpty(sortorder) ? "name_desc" : " ";
                ViewData["ageOrder"] = String.IsNullOrEmpty(sortorder) ? "age_desc" : "age_asc";
                switch (sortorder)
                {
                    case "name_desc":
                        trainees = trainees.OrderByDescending(s => s.Name);
                        break;
                    case "age_desc":
                       trainees = trainees.OrderByDescending(s => s.Tage);
                       break;
                    case "age_asc":
                       trainees = trainees.OrderBy(s => s.Tage);
                       break;
                    default:
                       trainees = trainees.OrderBy(s => s.Name);
                        break;
            }
            return View(trainees);

        }

            
                //return View(await _context.Trainees.ToListAsync())         
            

      

            // GET: Trainees/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tid,Name,Tage")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tid,Name,Tage")] Trainee trainee)
        {
            if (id != trainee.Tid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                    //toastNotification in yellow color - > WARNING
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Tid))
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
            return View(trainee);
        }
        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee != null)
            {
                _context.Trainees.Remove(trainee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return _context.Trainees.Any(e => e.Tid == id);
        }
        public async Task<IActionResult> UserOption(int? id)
        {
            // var trainee =  _context.Trainees;
            //return View(trainee);
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .FirstOrDefaultAsync(m => m.Tid == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }
    }
}
