using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Helpers;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private PustokDbContext _context;
        private IWebHostEnvironment _env;

        public BookController(PustokDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var books = _context.Books.Include(x => x.Author).Include(x => x.Genre).ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Genres.ToList();
                return View();
            }

            if(!_context.Authors.Any(x=>x.Id == book.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Author not found!");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Genres.ToList();
                return View();
            }

            if(_context.Genres.Any(x=>x.Id == book.GenreId))
            {
                ModelState.AddModelError("GenreId", "Genre not found!");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Genres.ToList();
                return View();
            }

            if(book.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "PosterFile is reqired!");
                ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Genres = _context.Genres.ToList();
                return View();
            }
            else
            {
                if (book.PosterFile.ContentType != "image/png" && book.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File format must be image/png or image/jpeg");
                }

                if (book.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size must be less than 2MB");
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.Authors = _context.Authors.ToList();
                    ViewBag.Genres = _context.Genres.ToList();
                    return View();
                }

                BookImage bookImage = new BookImage
                {
                    Name = FileManager.Save(_env.WebRootPath, "uploads/books", book.PosterFile),
                    PosterStatus = true
                };

                book.BookImages.Add(bookImage);

            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
