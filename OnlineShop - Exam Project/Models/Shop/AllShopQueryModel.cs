namespace OnlineShop___Exam_Project.Models.Shop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllShopQueryModel
    {
        public const int ProductsPerPage = 3;

        [Display(Name = "Model")]
        public string Modell { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public ShopSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProducts { get; set; }

        public IEnumerable<string> Models { get; set; }

        public IEnumerable<ShopListingViewModel> Products { get; set; }
    }
}
