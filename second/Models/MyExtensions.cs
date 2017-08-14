namespace second.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class MyExtensions
    {
        public static decimal TotalPrice(this ShoppingCart shoppingCart)
        {
            decimal total = 0;

            foreach (Product p in shoppingCart.Products)
            {
                total += p?.Price ?? 0;
            }

            return total;
        }

        public static decimal Total(this IEnumerable<Product> products)
        {
            decimal total = 0;

            foreach (var product in products)
            {
              total += product?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> products,
            decimal minimumPrice)
        {
            foreach (Product product in products)
            {
                if ((product?.Price ?? 0) >= minimumPrice)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products,
          Func<Product, bool> selector)
        {
            foreach (Product product in products)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
