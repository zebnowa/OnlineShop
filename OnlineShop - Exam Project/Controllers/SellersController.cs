namespace OnlineShop___Exam_Project.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop___Exam_Project.Data;
    using OnlineShop___Exam_Project.Data.Model;
    using OnlineShop___Exam_Project.Infrastructure;
    using OnlineShop___Exam_Project.Models.Sellers;
    using System.Linq;

    public class SellersController : Controller
    {
        private readonly OnlineShopDbContext data;
        public SellersController(OnlineShopDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Become()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeSellerFormModel seller)
        {
            var userId = this.User.GetId();

            var userIsAlreadySeller = this.data
                .Sellers
                .Any(s => s.UserId == userId);

            if (userIsAlreadySeller)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(seller);
            }

            var sellerData = new Seller
            {
                Name = seller.Name,
                PhoneNumber = seller.PhoneNumber,
                UserId = userId
            };

            this.data.Sellers.Add(sellerData);
            this.data.SaveChanges();

            return RedirectToAction("All", "Shop");
        }
    }
}
