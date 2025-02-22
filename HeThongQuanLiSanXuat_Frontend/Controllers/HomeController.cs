using System.Diagnostics;
using HeThongQuanLiSanXuat_Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLiSanXuat_Frontend.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sanpham()
        {
            return View();
        }

        public IActionResult Congdoan()
        {
            return View();
        }

        public IActionResult Lenhsanxuat()
        {
            return View();
        }

        public IActionResult Nhansu()
        {
            return View();
        }

        public IActionResult Phongban()
        {
            return View();
        }

        public IActionResult Thietbi()
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
