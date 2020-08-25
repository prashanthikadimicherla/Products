using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service
{
    public interface ISortService
    {
        IEnumerable<Models.Products> SortProducts(string sortOptions, List<Models.Products> products);
        IEnumerable<Models.Products> SortPreferredProducts(List<Models.Customer> customers);
    }
}
