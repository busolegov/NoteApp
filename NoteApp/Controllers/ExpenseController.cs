using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <Expense> expenseList = _db.Expenses;
            return View(expenseList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense) 
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);

        }

        //Post
        [HttpPost]
        public IActionResult Delete(int? id) 
        {
            var ex = _db.Expenses.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(ex);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult DeleteGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ex = _db.Expenses.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            return View(ex);
        }

        //Get
        public IActionResult UpdateGet(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ex = _db.Expenses.Find(id);
            if (ex == null)
            {
                return NotFound();
            }
            return View(ex);
        }

        //Post
        [HttpPost]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

    }
}
