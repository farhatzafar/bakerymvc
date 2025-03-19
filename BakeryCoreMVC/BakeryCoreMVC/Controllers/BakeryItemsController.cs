using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using BakeryCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryMVC.Controllers
{
    public class BakeryItemsController : Controller
    {
        private readonly BakeryDBContext _context;

        // Constructor
        public BakeryItemsController(BakeryDBContext context)
        {
            _context = context;
        }

        // GET: BakeryItems
        public IActionResult Index()
        {
            var bakeryItems = _context.BakeryItems.ToList();
            return View(bakeryItems);
        }

        // GET: BakeryItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var bakeryItem = _context.BakeryItems
                .FirstOrDefault(m => m.Id == id);

            if (bakeryItem == null)
            {
                return NotFound();
            }

            return View(bakeryItem);
        }

        // GET: BakeryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BakeryItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,ImageUrl")] BakeryItem bakeryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakeryItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(bakeryItem);
        }

        // GET: BakeryItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var bakeryItem = _context.BakeryItems.Find(id);
            if (bakeryItem == null)
            {
                return NotFound();
            }

            return View(bakeryItem);
        }

        // POST: BakeryItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl")] BakeryItem bakeryItem)
        {
            if (id != bakeryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakeryItem);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakeryItemExists(bakeryItem.Id))
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
            return View(bakeryItem);
        }

        // GET: BakeryItems/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var bakeryItem = _context.BakeryItems
                .FirstOrDefault(m => m.Id == id);
            if (bakeryItem == null)
            {
                return NotFound();
            }

            return View(bakeryItem);
        }

        // POST: BakeryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bakeryItem = _context.BakeryItems.Find(id);
            _context.BakeryItems.Remove(bakeryItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BakeryItemExists(int id)
        {
            return _context.BakeryItems.Any(e => e.Id == id);
        }
    }
}
