using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
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
    }
}
