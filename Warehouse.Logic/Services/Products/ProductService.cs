using System.Collections.Generic;
using System.Linq;
using Warehouse.DataProvider.Repositories.Products;
using Warehouse.Model.Entities;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> GetAllProductsForSale()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products.Select(item => new ProductViewModel
            {
                Name = item.Name,
                Description = item.Description,
                Type = item.ProductType.Name,
                SaleNumber = item.SaleNumber,
                TotalNumber = item.TotalNumber,
                Price = item.Price
            }).ToList();
        }

        public IEnumerable<ProductViewModel> GetNonSaleProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}