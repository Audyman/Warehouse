using System;
using System.Diagnostics;
using Warehouse.Database.Initializer;
using Warehouse.DataProvider.Database;


namespace Warehouse.Database
{
    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("Start Warehouse.Database project.");

            using (var dataContext = new WarehouseContext())
            {
                System.Data.Entity.Database.SetInitializer(new WarehouseInitializer());
                dataContext.Database.Initialize(false);
            }

            sw.Stop();
            Console.WriteLine("End at {0} s", sw.ElapsedMilliseconds / 1000);
        }
    }
}
