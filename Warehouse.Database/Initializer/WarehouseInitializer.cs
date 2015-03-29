using Warehouse.DataProvider.Database;
using Warehouse.Model.Entities;
using Warehouse.Model.Enums;

namespace Warehouse.Database.Initializer
{
    internal class WarehouseInitializer : BaseIDatabaseInitializer<WarehouseContext>
    {
        protected override void AddSystemData(WarehouseContext context)
        {
            //SystemData.AddTestData(context);
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
                Type = ProductType.StainlessSteelChimney,
                IsDeleted = false,
                Price = 28
            });

            #endregion

            context.SaveChanges();
        }
    }
}