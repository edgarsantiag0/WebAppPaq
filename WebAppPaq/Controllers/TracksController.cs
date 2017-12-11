using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPaq.Data;
using WebAppPaq.Models.Paq;
using Microsoft.AspNetCore.Authorization;

namespace WebAppPaq.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TracksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tracks.Include(t => t.DetalleFactura).Include(t => t.Estado).Include("DetalleFactura.Factura");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.DetalleFactura)
                .Include(t => t.Estado)
                .SingleOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            ViewData["DetalleFacturaId"] = new SelectList(_context.DetalleFacturas, "Id", "Id");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Descripcion");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackId,DetalleFacturaId,EstadoId")] Track track)
        {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DetalleFacturaId"] = new SelectList(_context.DetalleFacturas, "Id", "Id", track.DetalleFacturaId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "EstadoId", track.EstadoId);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks.SingleOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }
            ViewData["DetalleFacturaId"] = new SelectList(_context.DetalleFacturas, "Id", "Id", track.DetalleFacturaId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Descripcion", track.EstadoId);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackId,DetalleFacturaId,EstadoId")] Track track)
        {
            if (id != track.TrackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.TrackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DetalleFacturaId"] = new SelectList(_context.DetalleFacturas, "Id", "Id", track.DetalleFacturaId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "EstadoId", track.EstadoId);
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.DetalleFactura)
                .Include(t => t.Estado)
                .SingleOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.SingleOrDefaultAsync(m => m.TrackId == id);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackId == id);
        }

        [HttpPost]
        public JsonResult GetDetalleFacturaById([FromBody] DetalleFactura detalle)
        {
            var detalleFactura = _context.DetalleFacturas.SingleOrDefaultAsync(m => m.Id == detalle.Id);

            return Json(detalleFactura);
        }
    }
}
