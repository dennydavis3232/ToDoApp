using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext _context;

        public MainController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Main
        public IActionResult Index()
        {
            var todos = _context.TodoApp.ToList();
            return View(todos);
        }

        // GET: /Main/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Main/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                todo.CreatedAt = DateTime.Now;
                _context.TodoApp.Add(todo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: /Main/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _context.TodoApp.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: /Main/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TodoItem todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    if (!TodoExists(todo.Id))
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
            return View(todo);
        }
        // GET: /Main/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _context.TodoApp.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: /Main/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _context.TodoApp.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: /Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.TodoApp.Find(id);
            _context.TodoApp.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
         private bool TodoExists(int id)
        {
            return _context.TodoApp.Any(e => e.Id == id);
        }
    }
}
