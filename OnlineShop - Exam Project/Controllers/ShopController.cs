namespace OnlineShop___Exam_Project.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OnlineShop___Exam_Project.Data;
    using OnlineShop___Exam_Project.Data.Model;
    using OnlineShop___Exam_Project.Infrastructure;
    using OnlineShop___Exam_Project.Models.Shop;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ShopController : Controller
    {
        private readonly OnlineShopDbContext data;

        public ShopController(OnlineShopDbContext data)
            => this.data = data;

        public IActionResult All([FromQuery] AllShopQueryModel query)
        {
            var shopQuery = this.data.OnlineShops.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Modell))
            {
                shopQuery = shopQuery
                    .Where(s => s.Model == query.Modell);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                shopQuery = shopQuery.Where(s =>
                s.Model.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            shopQuery = query.Sorting switch
            {
                ShopSorting.Model => shopQuery.OrderByDescending(s => s.Id),
                ShopSorting.Category => shopQuery.OrderByDescending(s => s.Id),
                _ => shopQuery.OrderByDescending(s => s.Id)
            };

            var totalProducts = shopQuery.Count();

            var shop = shopQuery
                .Skip((query.CurrentPage - 1) * AllShopQueryModel.ProductsPerPage)
                .Take(AllShopQueryModel.ProductsPerPage)
                .Select(p => new ShopListingViewModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name
                })
                .ToList();

            var shopModels = this.data
                .OnlineShops
                .Select(s => s.Model)
                .OrderBy(s => s)
                .Distinct()
                .ToList();

            query.TotalProducts = totalProducts;
            query.Models = shopModels;
            query.Products = shop;

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsSeller())
            {
                return RedirectToAction(nameof(SellersController.Become), "Sellers");
            }

            return View(new AddShopFormModel
            {
                Categorys = this.GetShopCategorys()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddShopFormModel shop)
        {
            var sellerId = this.data
                .Sellers
                .Where(s => s.UserId == this.User.GetId())
                .Select(s => s.Id)
                .FirstOrDefault();

            if (sellerId == 0) 
            {
                return RedirectToAction(nameof(SellersController.Become), "Sellers");
            }

            if (!this.data.Categorys.Any(c => c.Id == shop.CategoryId))
            {
                this.ModelState.AddModelError(nameof(shop.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                shop.Categorys = this.GetShopCategorys();

                return View(shop);
            }

            var shopData = new Shop
            {
                Model = shop.Model,
                Size = shop.Size,
                Description = shop.Description,
                ImageUrl = shop.ImageUrl,
                CategoryId = shop.CategoryId,
                SellerId = sellerId
            };

            this.data.OnlineShops.Add(shopData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private bool UserIsSeller()
            =>  this.data
                .Sellers
                .Any(s => s.UserId == this.User.GetId());

        private IEnumerable<ShopCategoryViewModel> GetShopCategorys()
             => this.data
                .Categorys
                .Select(c => new ShopCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
    }
}


