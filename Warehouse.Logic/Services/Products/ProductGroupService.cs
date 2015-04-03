using System.Collections.Generic;
using Warehouse.DataProvider.Repositories.Products;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.Services.Products
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupService(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public IEnumerable<ProductGroupViewModel> GetAllActiveGroups()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductGroupViewModel> GetAllDeletedGroups()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductGroupViewModel> GetAllActiveGroupsByName(string nameQuery)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductGroupViewModel> GetGroupsById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}