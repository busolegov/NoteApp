using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Note> noteList = _db.Notes;
            return View(noteList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _db.Notes.Add(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);

        }

        public IActionResult Delete(int? id) 
        {
            var ex = _db.Notes.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            _db.Notes.Remove(ex);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGet(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ex = _db.Notes.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            return View(ex);
        }

        [HttpPost]
        public IActionResult Update(Note note) 
        {
            if (ModelState.IsValid)
            {
                _db.Notes.Update(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Update(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ex = _db.Notes.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            return View(ex);
        }
    }
}
