
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloLocal.Web.Models;
using HelloLocal.Web.Data;
using Microsoft.AspNetCore.Authorization;

public class LocalGuidesController : Controller
{
    private readonly ApplicationDbContext _context;

    public LocalGuidesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: LOCALGUIDES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Guides.ToListAsync());
    }

    // GET: LOCALGUIDES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var localguide = await _context.Guides
            .FirstOrDefaultAsync(m => m.Id == id);
        if (localguide == null)
        {
            return NotFound();
        }

        return View(localguide);
    }

    // GET: LOCALGUIDES/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: LOCALGUIDES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("Id,Name,City,Bio,HourlyRate")] LocalGuide localGuide)
    {
        ModelState.Remove("Experiences"); 

        if (ModelState.IsValid)
        {
            _context.Add(localGuide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(localGuide);
    }
    // GET: LOCALGUIDES/Edit/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var localguide = await _context.Guides.FindAsync(id);
        if (localguide == null)
        {
            return NotFound();
        }
        return View(localguide);
    }

    // POST: LOCALGUIDES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Bio,HourlyRate")] LocalGuide localGuide)
    {
        if (id != localGuide.Id)
        {
            return NotFound();
        }

      
        ModelState.Remove("Experiences");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(localGuide);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalGuideExists(localGuide.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(localGuide);
    }

    // GET: LOCALGUIDES/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var localguide = await _context.Guides
            .FirstOrDefaultAsync(m => m.Id == id);
        if (localguide == null)
        {
            return NotFound();
        }

        return View(localguide);
    }

    // POST: LOCALGUIDES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var localguide = await _context.Guides.FindAsync(id);
        if (localguide != null)
        {
            _context.Guides.Remove(localguide);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LocalGuideExists(int? id)
    {
        return _context.Guides.Any(e => e.Id == id);
    }
}
