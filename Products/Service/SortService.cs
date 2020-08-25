using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Products.Extensions;

namespace Products.Service
{
    public class SortService :ISortService
    {
        public IEnumerable<Models.Products> SortProducts(string sortOptions, List<Models.Products> products)
        {
            var sortBy = SortBy().FirstOrDefault(s => s.Key.Equals(sortOptions, StringComparison.OrdinalIgnoreCase)).Value;
            var sortOrder = SortOrder().FirstOrDefault(s => s.Key.Equals(sortOptions, StringComparison.OrdinalIgnoreCase)).Value;

            return products.AsQueryable().Sort(sortBy, Convert.ToBoolean(sortOrder));
        }
        public IEnumerable<Models.Products> SortPreferredProducts(List<Models.Customer> customers)
        {
            var products = customers.SelectMany(c => c.products);
            return products.GroupBy(p => p.Name).Select(cl => new Models.Products
            {
                Name = cl.First().Name,
                Quantity = cl.Sum(p => p.Quantity),
                Price = cl.First().Price,
            }).ToList();
        }

        private static Dictionary<string, string> SortBy()
        {
            return new Dictionary<string, string>
            {
                {"high", "Price"},
                {"low", "Price"},
                {"ascending", "Name"},
                {"descending", "Name"}
            };

        }
        private static Dictionary<string, bool> SortOrder()
        {
            return new Dictionary<string, bool>
            {
                {"high", false},
                {"low", true},
                {"ascending", true},
                {"descending", false}
            };

        }
    }
}