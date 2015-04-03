using System.Collections.Generic;
using Warehouse.ViewModel.Products;

namespace Warehouse.Logic.Services.Products
{
    public interface IProductGroupService
    {
        IEnumerable<ProductGroupViewModel> GetAllActiveGroups();
        IEnumerable<ProductGroupViewModel> GetAllDeletedGroups();
        IEnumerable<ProductGroupViewModel> GetAllActiveGroupsByName(string nameQuery);
        IEnumerable<ProductGroupViewModel> GetGroupsById(int id);

    }
}