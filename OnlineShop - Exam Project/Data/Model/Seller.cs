namespace OnlineShop___Exam_Project.Data.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    using static DataConstants.Seller;
    public class Seller
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLegth)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Shop> OnlineShops { get; init; } = new List<Shop>();
    }
}
