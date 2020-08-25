using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service
{
    public interface IResoureService
    {
        List<Models.Products> GetProducts();
        List<Models.Customer> GetShopperHistory();
    }
}
