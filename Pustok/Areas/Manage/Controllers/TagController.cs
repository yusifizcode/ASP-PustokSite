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
    public class TagController : Controller
    {
        private PustokDbContext _context;

        public TagController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tags = _context.Tags.Include(x=>x.BookTags).ToList();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(tag);
        }

        [HttpPost]
        public IActionResult Edit(int id, Tag tag)
        {
            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (existTag == null)
            {
                return RedirectToAction("error", "dashboard");
            }


            existTag.Name = tag.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (tag == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}