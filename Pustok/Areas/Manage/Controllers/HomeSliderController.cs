using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Helpers;
using Pustok.Models;
using System.Linq;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class HomeSliderController : Controller
    {
        private PustokDbContext _context;
        private IWebHostEnvironment _env;

        public HomeSliderController(PustokDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var sliders = _context.HomeSliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeSlider slider)
        {
            if (slider.ImageFile != null)
            {
                if(slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Image content type must be png, jpg or jpeg!");
                }

                if(slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size must be less than 2MB!");
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image file is required!");
            }

            slider.Image = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);

            _context.HomeSliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HomeSlider slider = _context.HomeSliders.FirstOrDefault(x => x.Id == id);
            if(slider == null)
            {
                return NotFound();
            }

            FileManager.Delete(_env.WebRootPath, "uploads/sliders", slider.Image);

            _context.HomeSliders.Remove(slider);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Edit(int id)
        {
            HomeSlider slider = _context.HomeSliders.FirstOrDefault(x => x.Id == id);

            if(slider == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(HomeSlider slider)
        {
            HomeSlider existSlider = _context.HomeSliders.FirstOrDefault(x => x.Id == slider.Id);

            if (slider == null)
                return RedirectToAction("error", "dashboard");

            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File format must be image/png or image/jpeg");
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size must be less than 2MB");
                }

                if (!ModelState.IsValid)
                    return View();

                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);

                FileManager.Delete(_env.WebRootPath, "uploads/sliders", existSlider.Image);

                existSlider.Image = newFileName;
            }



            existSlider.Title = slider.Title;
            existSlider.Desc = slider.Desc;
            existSlider.BtnUrl = slider.BtnUrl;
            existSlider.BtnText = slider.BtnText;
            existSlider.Order = slider.Order;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
