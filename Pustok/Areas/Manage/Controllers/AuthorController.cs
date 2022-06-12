using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly PustokDbContext _context;

        public AuthorController(PustokDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var authors = _context.Authors.Include(x => x.Books).ToList();
            return View(authors);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(author);
        }
    }
}
