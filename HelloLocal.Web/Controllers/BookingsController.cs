using HelloLocal.Web.Data;
using HelloLocal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class BookingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: BOOKINGS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Bookings.Include(b => b.Experience).ToListAsync());
    }

    // GET: BOOKINGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings
            .Include(b => b.Experience)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    // GET: BOOKINGS/Create
    public IActionResult Create()
    {
        ViewBag.Experiences = new SelectList(_context.TourExperiences, "Id", "Title");
        return View();
    }

    // POST: BOOKINGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TouristName,BookingDate,TourExperienceId")] Booking booking)
    {
        ModelState.Remove("Experience");

        if (ModelState.IsValid)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Experiences = new SelectList(_context.TourExperiences, "Id", "Title", booking.TourExperienceId);
        return View(booking);
    }

    // GET: BOOKINGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }

        ViewBag.Experiences = new SelectList(_context.TourExperiences, "Id", "Title", booking.TourExperienceId);
        return View(booking);
    }

    // POST: BOOKINGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,TouristName,BookingDate,TourExperienceId")] Booking booking)
    {
        if (id != booking.Id)
        {
            return NotFound();
        }

        ModelState.Remove("Experience");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.Id))
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

        ViewBag.Experiences = new SelectList(_context.TourExperiences, "Id", "Title", booking.TourExperienceId);
        return View(booking);
    }

    // GET: BOOKINGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings
            .Include(b => b.Experience)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    // POST: BOOKINGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookingExists(int? id)
    {
        return _context.Bookings.Any(e => e.Id == id);
    }
}