using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
using Warehouse.Model.Entities;

namespace Warehouse.DataProvider.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class WarehouseContext : DbContext, IWarehouseContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void CloseContext()
        {
            Dispose();
        }

        public override int SaveChanges()
        {
            return SaveChangesInternal();
        }

        internal int SaveChangesInternal()
        {
            try
            {
                var result = base.SaveChanges();

                return result;
            }
            catch (DbEntityValidationException exception)
            {
                var sb = new StringBuilder();

                foreach (var failure in exception.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb, exception);
            }
            catch (DbUpdateException updateException)
            {
                if (updateException.InnerException != null)
                {
                    updateException.Data.Add("DbEntityValidation", "Database Error");
                }
                throw;
            }
        }
    }
}