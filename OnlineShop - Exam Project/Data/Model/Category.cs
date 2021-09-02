namespace OnlineShop___Exam_Project.Data.Model
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Category;
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; init; }

        public IEnumerable<Shop> OnlineShops { get; init; } 
            = new List<Shop>();
    }
}
