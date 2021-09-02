namespace OnlineShop___Exam_Project.Models.Shop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Shop;
    public class AddShopFormModel
    {
        [Display(Name = "Title")]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        [Required]
        public string Model { get; init; }

        [Required]
        public string Size { get; init; }

        [Required]
        [StringLength
            (int.MaxValue, MinimumLength = DescriptionMinLength,
            ErrorMessage = "The Description must be minimum 10 symbols!")]
        public string Description { get; init; }

        [Required]
        [Url]
        [Display(Name = "Photos")]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<ShopCategoryViewModel> Categorys { get; set; }
    }
}
