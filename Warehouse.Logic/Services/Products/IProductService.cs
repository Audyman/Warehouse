using System.Collections.Generic;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.Services.Products
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProductsForSale();
        IEnumerable<ProductViewModel> GetAllProducts();
        IEnumerable<ProductViewModel> GetNonSaleProducts();
    }
}