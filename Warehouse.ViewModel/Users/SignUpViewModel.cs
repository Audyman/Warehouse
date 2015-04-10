using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Users
{
    public class SignUpViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageMaxLength100")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        public bool IsAgreementChecked { get; set; }

        public bool IsAdmin { get; set; }
    }
}