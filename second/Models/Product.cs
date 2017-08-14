namespace second.Models
{
    using System;

    public class Product
    {
        public Product(bool inStock = true)
        {
            InStock = inStock;
        }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";
        public bool ToSell { get; } = true;
        public bool InStock { get; }
        public Product Related { get; set; }
        public bool NameBeginsWithS => Name?[0] == 'S';

        public static Product[] GetProducts()
        {
            var kayak = new Product() { Name = "Kayak", Price = 275m, Category = "Water Craft" };
            var lifejack = new Product(false) { Name = "LifeJacket", Price = 48.95m };
            var ball = new Product() { Name = "Soccer Ball", Price = 19.50m };
            var flag = new Product() { Name = "Cooner Flag", Price = 34.69m };

            kayak.Related = kayak;

            return new Product[]
            {
                kayak,
                lifejack,
                ball,
                flag,
                null
            };
        }
    }
}
