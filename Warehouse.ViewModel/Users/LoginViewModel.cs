using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}