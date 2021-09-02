namespace OnlineShop___Exam_Project.Models.Sellers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static Data.DataConstants.Seller;
    public class BecomeSellerFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLegth, MinimumLength = PhoneNumberMinLegth)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
