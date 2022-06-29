using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class ShopController : Controller
    {
        private PustokDbContext _context;

        public ShopController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Genres = _context.Genres.ToList(),
            };
            return View(shopVM);
        }

        public IActionResult Detail(int id)
        {
            Book book = _context.Books
                .Include(x=>x.Author)
                .Include(x=>x.Genre)
                .Include(x=>x.BookImages)
                .Include(x=>x.BookTags)
                .ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id);

            if (book == null)
                return RedirectToAction("error", "dashboard");

            BookDetailViewModel detailVM = new BookDetailViewModel
            {
                Book = book,
                RelatedBooks = _context.Books.Where(x => x.GenreId == book.GenreId).Take(6).ToList(),
                BookComment = new PostBookCommentViewModel { BookId = id}
            };

            return View(detailVM);
        }
    }
}
