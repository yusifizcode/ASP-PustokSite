using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private PustokDbContext _context;

        public SettingController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var settings = _context.Settings.ToDictionary(x=>x.Key,y=>y.Value);
            return View(settings);
        }
    }
}
