using EntityFrameWork.Data;
using EntityFrameWork.Models;
using EntityFrameWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFrameWork.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            SliderInfo sliderInfo = _context.SliderInfos.FirstOrDefault();
            IEnumerable<Blog> blogs = _context.Blogs.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Category>categories=_context.Categories.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Product>products=_context.Products.Include(m=>m.Images).Where(m => !m.SoftDelete).ToList();
            IEnumerable<About>abouts= _context.Abouts.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Advantage> advantages = _context.Advantages.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Flower> flowers = _context.Flowers.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Workers> workers = _context.Workers.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Florist> florists = _context.Florists.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Instagram> instagrams = _context.Instagrams.Where(m => !m.SoftDelete).ToList();
            IEnumerable<Subscribe> subscribes = _context.Subscribes.Where(m => !m.SoftDelete).ToList();
            HomeVm model = new()
            {
                Sliders = sliders,
                Sliderİnfo = sliderInfo,
                Blogs=blogs,
                Categories=categories,
                Products=products,
                Abouts=abouts,
                Advantages=advantages,
                Flowers=flowers,
                Workers=workers,
                Florists = florists,
                Instagrams=instagrams,
                Subscribes=subscribes
                
            };

            return View(model);
        }
    }
}