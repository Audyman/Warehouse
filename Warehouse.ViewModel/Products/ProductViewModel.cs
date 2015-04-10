using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Products
{
    public class ProductViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public string Type { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public int TotalNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public int SaleNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLengthDescription")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public int Price { get; set; }
    }
}