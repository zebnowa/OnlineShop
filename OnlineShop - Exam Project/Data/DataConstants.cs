namespace OnlineShop___Exam_Project.Data
{
    public class DataConstants
    {
        public class Shop
        {
            public const int ModelMaxLength = 40;
            public const int ModelMinLength = 3;
            public const int DescriptionMinLength = 10;
        }

        public class Category
        {
            public const int NameMaxLength = 25;
        }

        public class Seller
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;
            public const int PhoneNumberMinLegth = 6;
            public const int PhoneNumberMaxLegth = 30;
        }
    }
}
