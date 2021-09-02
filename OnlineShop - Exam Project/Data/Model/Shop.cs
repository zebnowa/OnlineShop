namespace OnlineShop___Exam_Project.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Shop;
    public class Shop
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        public string Model { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int SellerId { get; init; }

        public Seller Seller { get; init; }
    }
}
