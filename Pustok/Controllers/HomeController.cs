using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pustok.DAL;
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
                HomeFeatures = _context.HomeFeatures.ToList()
            };
            return View(homeVM);
        }
    }
}



