using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
//using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private PustokDbContext _context;

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                HomeSliders = _context.HomeSliders.ToList(),
                HomeFeatures = _context.HomeFeatures.ToList(),
                NewBooks = _context.Books.Include(x => x.BookImages).Include(x => x.Author).Where(x => x.IsNew).Take(20).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.BookImages).Include(x => x.Author).Where(x => x.DiscountPercent > 0).Take(20).ToList(),
                FeaturedBooks = _context.Books.Include(x => x.BookImages).Include(x => x.Author).Where(x => x.IsFeatured).Take(20).ToList()
            };
            return View(homeVM);
        }

        public IActionResult GetBookDetail(int id)
        {
            Book book = _context.Books.FirstOrDefault(x=>x.Id == id);

            if (book == null)
                return NotFound();

            return Json(new Book {
                Name = book.Name,
                TagIds = book.TagIds,
                SalePrice = book.SalePrice,
                IsAvailable = book.IsAvailable,
                DiscountPercent = book.DiscountPercent,
                Desc = book.Desc,
                BookImages= book.BookImages
            }) ;
        }
    }
}



