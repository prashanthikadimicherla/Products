using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
namespace Products.Extensions
{
    public static class Extensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy, bool isAscending)
        {
            var orderQueryBuilder = new StringBuilder();
            if (!source.Any())
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                throw new ArgumentNullException(nameof(source));
            }

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
          
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                throw new ArgumentNullException("The source does not match the product properties");
           
            var sortingOrder = isAscending ? "ascending" : "descending";
            orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder} ");

            return source.OrderBy(orderQueryBuilder.ToString());
        }
    }
}