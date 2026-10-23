
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloLocal.Web.Models;
using HelloLocal.Web.Data;

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
    public IActionResult Create()
    {
        return View();
    }

    // POST: LOCALGUIDES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Bio,HourlyRate,Experiences")] LocalGuide localguide)
    {
        if (ModelState.IsValid)
        {
            _context.Add(localguide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(localguide);
    }

    // GET: LOCALGUIDES/Edit/5
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
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Bio,HourlyRate,Experiences")] LocalGuide localguide)
    {
        if (id != localguide.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(localguide);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalGuideExists(localguide.Id))
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
        return View(localguide);
    }

    // GET: LOCALGUIDES/Delete/5
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
