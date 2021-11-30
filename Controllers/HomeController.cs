using ClientConnecting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ClientConnecting.Services;

namespace ClientConnecting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClientConnectingContext _context;
        private readonly CompanyService _companyService;
        private readonly ClientService _clientService;

        public HomeController(ILogger<HomeController> logger, ClientConnectingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> Privacy()
        {
            ViewData["email"] = "teste@gmail.com";
            return View();
        }

        public async Task<IActionResult> Register()
        {
            ViewData["email"] = "teste@gmail.com";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Search()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewModel mymodel = new ViewModel();
            return View(mymodel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Email,Password")] Company company)
        {
            var user = await _context.Company
                .FirstOrDefaultAsync(m => m.Email == company.Email);

            if (user == null)
            {
                ViewBag.Message = "Usuário e/ou Senha inválidos!";
                return View();
            }

            bool isSenhaOk = BCrypt.Net.BCrypt.Verify(company.Password, user.Password);

            if (isSenhaOk)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.Role, user.Perfil.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");

            }

            ViewBag.Message = "Usuário e/ou Senha inválidos!";
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }
    }
}
