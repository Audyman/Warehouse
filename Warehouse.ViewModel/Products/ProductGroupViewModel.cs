using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Products
{
    public class ProductGroupViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public string Name { get; set; }
    }
}