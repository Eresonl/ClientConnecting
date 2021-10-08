using ClientConnecting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CarrouselIndex> CarrouselIndex = new List<CarrouselIndex>();
            CarrouselIndex.Add(new CarrouselIndex()
            {
                Id = 1,
                Title = "Some 1",
                Img = "bannerImage1Formated.jpg"

            });
            
            CarrouselIndex.Add(new CarrouselIndex()
            {
                Id = 2,
                Title = "Some 2",
                Img = "bannerImage2Formated.jpg"

            });

            CarrouselIndex.Add(new CarrouselIndex()
            {
                Id = 3,
                Title = "Some 3",
                Img = "bannerImage3Formated.jpg"

            });


            return View(CarrouselIndex);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
