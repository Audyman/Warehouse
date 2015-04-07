using Warehouse.Database.Configuration;
using Warehouse.DataProvider.Database;
using Warehouse.Model.Entities;
using Warehouse.Providers.Security;

namespace Warehouse.Database.Initializer
{
    internal class WarehouseInitializer : BaseIDatabaseInitializer<WarehouseContext>
    {
        protected override void AddSystemData(WarehouseContext context)
        {
            const string playerRoleName = "Standartuser";
            const string administratorRoleName = "Administrator";

            MySqlWebSecurity.InitializeDatabaseConnection(DbConfigManager.ConnectionName);
            System.Web.Security.Roles.CreateRole(administratorRoleName);
            System.Web.Security.Roles.CreateRole(playerRoleName);
        }

        protected override void AddTestData(WarehouseContext context)
        {
            #region Products Test Data

            context.Products.Add(new Product
            {
                Name = "Tube 1",
                Description = "Good Tube",
                SaleNumber = 5,
                TotalNumber = 7,
                ProductType = new ProductType
                              {
                                  IsDeleted = false,
                                  Name = "Test Type 1",
                                  ProductGroup = new ProductGroup
                                                 {
                                                     IsDeleted = false,
                                                     Name = "Test Group 1"
                                                 }
                              },
                IsDeleted = false,
                Price = 28
            });

            #endregion

            context.SaveChanges();
        }
    }
}