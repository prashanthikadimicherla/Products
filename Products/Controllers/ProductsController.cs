using System;
using System.Collections.Generic;
using System.Web.Http;
using Products.Service;

namespace Products.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IResoureService _resourceService;

        private readonly ISortService _sortService;
        public ProductsController(IResoureService resourceService, ISortService sortService)
        {
            _resourceService = resourceService;
            _sortService = sortService;
        }

        [HttpGet, Route("api/sort")]
        public IEnumerable<Models.Products> SortProducts(string sortOptions)
        {
            if (sortOptions.Equals(Constants.Recommended, StringComparison.OrdinalIgnoreCase))
            {
                var customerProducts = _resourceService.GetShopperHistory();
                return _sortService.SortPreferredProducts(customerProducts);
            }
            var products = _resourceService.GetProducts();
            return _sortService.SortProducts(sortOptions, products);
        }

      
    }
}
