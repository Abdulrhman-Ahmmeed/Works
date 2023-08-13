using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entity;
using Infrastructure;
using Core.Interfaces;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookContext _context;
        private readonly IGenericRepository<Author> _autorRepo;

        public AuthorsController(BookContext context,IGenericRepository<Author> autorRepo)
        {
            _context = context;
            _autorRepo = autorRepo;
        }

        // GET: Authors
        public  IActionResult Index()
        {
            return View( _autorRepo.List());
        }

        // GET: Authors/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author =  _autorRepo.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([Bind("FullName,Id")] Author author)
        {
            if (ModelState.IsValid)
            {
                
                 _autorRepo.Add(author);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5int
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author =   _autorRepo.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int? id, Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                    _autorRepo.Update(author);
                    _context.SaveChanges();
               
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author =   _autorRepo.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var author =  _autorRepo.Find(id);
             _context.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // private bool AuthorExists(int? id)
        // {
        //     return _context.authors.Any(e => e.Id == id);
        // }
    }
}
