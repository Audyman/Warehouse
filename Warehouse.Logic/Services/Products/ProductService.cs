using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Warehouse.DataProvider.Repositories.Products;
using Warehouse.Model.Entities;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMappingEngine _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMappingEngine mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProductsForSale()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products.Select(item => _mapper.Map<Product, ProductViewModel>(item)).ToList();
        }

        public IEnumerable<ProductViewModel> GetNonSaleProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}