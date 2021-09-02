namespace OnlineShop___Exam_Project.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalProducts { get; init; }

        public int TotalUsers { get; init; }

        public List<ShopIndexViewModel> Products { get; init; }
    }
}
