using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CBTSWE2_TP02.Data;
using CBTSWE2_TP02.Models;

namespace CBTSWE2_TP02.Controllers
{
    public class ContainerOBJsController : Controller
    {
        private readonly CBTSWE2_TP02Context _context;

        public ContainerOBJsController(CBTSWE2_TP02Context context)
        {
            _context = context;
        }

        // GET: ContainerOBJs
        public async Task<IActionResult> Index()
        {
            var cBTSWE2_TP02Context = _context.Containers.Include(c => c.Bl);
            return View(await cBTSWE2_TP02Context.ToListAsync());
        }

        // GET: ContainerOBJs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerOBJ = await _context.Containers
                .Include(c => c.Bl)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (containerOBJ == null)
            {
                return NotFound();
            }

            return View(containerOBJ);
        }

        // GET: ContainerOBJs/Create
        public IActionResult Create()
        {
            ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero");
            return View();
        }

        // POST: ContainerOBJs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("ID,Numero,Tipo,Tamanho,BLId")] ContainerOBJ containerOBJ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(containerOBJ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLId"] = new SelectList(
                _context.BLs,
                "ID",
                "Numero",
                containerOBJ.BLId);

            return View(containerOBJ);
        }

        // GET: ContainerOBJs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerOBJ = await _context.Containers.FindAsync(id);
            if (containerOBJ == null)
            {
                return NotFound();
            }
            ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero", containerOBJ.BLId);
            return View(containerOBJ);
        }

        // POST: ContainerOBJs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Tipo,Tamanho,BLId")] ContainerOBJ containerOBJ)
        {
            if (id != containerOBJ.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(containerOBJ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerOBJExists(containerOBJ.ID))
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
            ViewData["BLId"] = new SelectList(_context.BLs, "ID", "Numero", containerOBJ.BLId);
            return View(containerOBJ);
        }

        // GET: ContainerOBJs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerOBJ = await _context.Containers
                .Include(c => c.Bl)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (containerOBJ == null)
            {
                return NotFound();
            }

            return View(containerOBJ);
        }

        // POST: ContainerOBJs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var containerOBJ = await _context.Containers.FindAsync(id);
            if (containerOBJ != null)
            {
                _context.Containers.Remove(containerOBJ);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerOBJExists(int id)
        {
            return _context.Containers.Any(e => e.ID == id);
        }
    }
}
