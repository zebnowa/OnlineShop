namespace OnlineShop___Exam_Project.Controllers
{
    using System.Linq;
    using OnlineShop___Exam_Project.Data;
    using OnlineShop___Exam_Project.Models;
    using OnlineShop___Exam_Project.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly OnlineShopDbContext data;

        public HomeController(OnlineShopDbContext data)
            => this.data = data;

        public IActionResult Index()
        {
            var totalProducts = this.data.OnlineShops.Count();

            var shop = this.data
                   .OnlineShops
                   .OrderByDescending(p => p.Id)
                   .Select(p => new ShopIndexViewModel
                   {
                       Id = p.Id,
                       Model = p.Model,
                       ImageUrl = p.ImageUrl
                   })
                   .Take(3)
                   .ToList();

            return View(new IndexViewModel
            {
                TotalProducts = totalProducts,
                Products = shop
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
            => View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
