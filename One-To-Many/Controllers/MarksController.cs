using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using One_To_Many.Models;

namespace One_To_Many.Controllers
{
    public class MarksController : Controller
    {
        private readonly StudentContext _context;

        public MarksController(StudentContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()

        {


            var studentContext = _context.Marks.Include(m => m.Student);
            return View(await studentContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StuId", "StuName");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkId,StudentId,English,Maths,Social")] Mark mark)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(mark);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["StudentName"] = new SelectList(_context.Students, "StuId", "StuName", mark.StudentId);
            _context.Add(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StuId", "StuId", mark.StudentId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkId,StudentId,English,Maths,Social")] Mark mark)
        {
            //if (id != mark.MarkId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(mark);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MarkExists(mark.MarkId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["StudentId"] = new SelectList(_context.Students, "StuId", "StuId", mark.StudentId);
            _context.Update(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.MarkId == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Marks.FindAsync(id);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Marks.Any(e => e.MarkId == id);
        }
    }
}
