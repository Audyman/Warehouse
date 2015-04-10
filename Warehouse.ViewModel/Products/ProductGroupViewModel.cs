using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Products
{
    public class ProductGroupViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string Name { get; set; }
    }
}