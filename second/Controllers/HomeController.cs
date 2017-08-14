namespace second.Controllers
{
    using System;
    using System.Collections.Generic;
    using second.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        bool FilterExpensivePrice(Product p) => (p?.Price ?? 0) >= 100;

        public async Task<ViewResult> Index()
        {
            List<string> results = new List<string>();

            var products = new Dictionary<string, Product>
            {
                ["Soap"] = new Product(false) { Name = "Soap", Price = 22.35m },
                ["Shampoo"] = new Product(false) { Name = "Shampoo", Price = 78.89m }
            };

            Func<Product, bool> nameFilter = delegate(Product product)
            {
                return product?.Name?[0] == 'S';
            };

            foreach (Product p in Product.GetProducts().Filter(FilterExpensivePrice))
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0m;
                string relatedName = p?.Related?.Name ?? "<None>";

                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}",
                    //name, price, relatedName));
                results.Add($"{nameof(p.Name)}: {name}, {nameof(p.Price)}: {price:C2}, {nameof(p.Related)}: {relatedName}");
            }

            ShoppingCart cart = new ShoppingCart()
            {
                Products = Product.GetProducts().FilterByPrice(20)
            };

            Order order = new Order()
            {
                Products = Product.GetProducts()
            };

            decimal total = cart.TotalPrice();
            decimal totalOnlyExpensives = order.Filter(FilterExpensivePrice).Total();

            results.Add($"Total: {total:C2}");

            var yahooLenght = await MyAsyncMethods.GetPageLengthOldWay();
            var appleLenght = await MyAsyncMethods.GetPageLengthNewWay();

            results.Add("");
            results.Add($"Length of yahoo page is {yahooLenght} \r\nLength of apple page is {appleLenght}");

            return View(results);

            //return View(new string[] {"C#", "Language", "Features"});
        }
    }
}
