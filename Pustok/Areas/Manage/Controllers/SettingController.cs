using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Models;
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

        
        public IActionResult Edit(string id)
        {
            var existSetting = _context.Settings.FirstOrDefault(x=>x.Key == id);

            if (existSetting == null)
                return RedirectToAction("error", "dashboard");

            return View(existSetting);
        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            var existSetting = _context.Settings.FirstOrDefault(x=>x.Key==setting.Key);

            if (existSetting == null)
                return RedirectToAction("error", "dashboard");

            existSetting.Value = setting.Value;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
