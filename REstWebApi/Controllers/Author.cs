using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REstWebApi.Controllers
{
    public class Author : Controller
    {
        private readonly DataContext _context;
        public Author( DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var result =await  _context.Authors.Include(x=> x.AuthorsBooks).ToListAsync();
            return View(result);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _context.Authors.Include(x => x.AuthorsBooks).ThenInclude(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Authors author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
                return View(author);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Authors author)
        {
            _context.Attach(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid? id)
        {
            if (id != null)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(p => p.Id == id);
                if (author != null)
                    return View(author);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
                if(author is not null)
                {
                    _context.Remove(author);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
