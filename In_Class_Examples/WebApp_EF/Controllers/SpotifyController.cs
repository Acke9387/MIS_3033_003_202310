using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_EF.Models;

namespace WebApp_EF.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly DB_128040_practiceContext _context;

        public SpotifyController(DB_128040_practiceContext context)
        {
            _context = context;
        }


        // GET: Spotify
        public async Task<IActionResult> Index(string id = "", string genre = "")
        {
            if (_context.Spotify == null)
            {
                return Problem("Entity set 'DB_128040_practiceContext.Spotify'  is null.");
            }

            List<Spotify> songs = new List<Spotify>();

            if (genre == null)
            {
                songs = await _context.Spotify.ToListAsync();
            }
            else
            {
                songs = await _context.Spotify.Where(song => song.TopGenre == genre).ToListAsync();
            }
            return View(songs);
        }


        // GET: Spotify/Genres
        public async Task<IActionResult> Genres()
        {
            List<string> genres = new List<string>();
            //foreach (var song in _context.Spotify.ToList())
            //{
            //    if (genres.Contains(song.TopGenre) == false)
            //    {
            //        genres.Add(song.TopGenre); 
            //    }
            //}

            genres = _context.Spotify.Select(song => song.TopGenre).Distinct().ToList();

            return View(genres);
        }

        // GET: Spotify/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spotify == null)
            {
                return NotFound();
            }

            var spotify = await _context.Spotify
                .FirstOrDefaultAsync(m => m.Index == id);
            if (spotify == null)
            {
                return NotFound();
            }

            return View(spotify);
        }

        // GET: Spotify/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spotify/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Index,Title,Artist,TopGenre,Year,BeatsPerMinute,Energy,Danceability,Loudness,Liveness,Valence,Duration,Acousticness,Speechiness,Popularity")] Spotify spotify)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spotify);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spotify);
        }

        // GET: Spotify/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spotify == null)
            {
                return NotFound();
            }

            var spotify = await _context.Spotify.FindAsync(id);
            if (spotify == null)
            {
                return NotFound();
            }
            return View(spotify);
        }

        // POST: Spotify/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Index,Title,Artist,TopGenre,Year,BeatsPerMinute,Energy,Danceability,Loudness,Liveness,Valence,Duration,Acousticness,Speechiness,Popularity")] Spotify spotify)
        {
            if (id != spotify.Index)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spotify);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotifyExists(spotify.Index))
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
            return View(spotify);
        }

        // GET: Spotify/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spotify == null)
            {
                return NotFound();
            }

            var spotify = await _context.Spotify
                .FirstOrDefaultAsync(m => m.Index == id);
            if (spotify == null)
            {
                return NotFound();
            }

            return View(spotify);
        }

        // POST: Spotify/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spotify == null)
            {
                return Problem("Entity set 'DB_128040_practiceContext.Spotify'  is null.");
            }
            var spotify = await _context.Spotify.FindAsync(id);
            if (spotify != null)
            {
                _context.Spotify.Remove(spotify);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotifyExists(int id)
        {
            return (_context.Spotify?.Any(e => e.Index == id)).GetValueOrDefault();
        }
    }
}
