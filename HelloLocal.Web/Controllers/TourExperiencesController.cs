
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloLocal.Web.Models;
using HelloLocal.Web.Data;

public class TourExperiencesController : Controller
{
    private readonly ApplicationDbContext _context;

    public TourExperiencesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TOUREXPERIENCES
    public async Task<IActionResult> Index(string search_word, decimal? max_money)
    {
        var the_tours_list = from t in _context.TourExperiences select t;

        if (!String.IsNullOrEmpty(search_word))
        {
            the_tours_list = the_tours_list.Where(s => s.Title.Contains(search_word) || s.Description.Contains(search_word));
        }

        if (max_money.HasValue)
        {
            the_tours_list = the_tours_list.Where(t => t.Price <= max_money.Value);
        }

        return View(await the_tours_list.ToListAsync());
    }
    // GET: TOUREXPERIENCES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tourexperience = await _context.Experiences
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tourexperience == null)
        {
            return NotFound();
        }

        return View(tourexperience);
    }

    // GET: TOUREXPERIENCES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TOUREXPERIENCES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Description,LocalGuideId,Guide")] TourExperience tourexperience)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tourexperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tourexperience);
    }

    // GET: TOUREXPERIENCES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tourexperience = await _context.Experiences.FindAsync(id);
        if (tourexperience == null)
        {
            return NotFound();
        }
        return View(tourexperience);
    }

    // POST: TOUREXPERIENCES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Description,LocalGuideId,Guide")] TourExperience tourexperience)
    {
        if (id != tourexperience.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tourexperience);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExperienceExists(tourexperience.Id))
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
        return View(tourexperience);
    }

    // GET: TOUREXPERIENCES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tourexperience = await _context.Experiences
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tourexperience == null)
        {
            return NotFound();
        }

        return View(tourexperience);
    }

    // POST: TOUREXPERIENCES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var tourexperience = await _context.Experiences.FindAsync(id);
        if (tourexperience != null)
        {
            _context.Experiences.Remove(tourexperience);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TourExperienceExists(int? id)
    {
        return _context.Experiences.Any(e => e.Id == id);
    }
}
