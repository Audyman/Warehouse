using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Users
{
    public class LoginViewModel
    {
        public LoginViewModel() { }

        [Required(ErrorMessage = "Required.")]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }
    }
}