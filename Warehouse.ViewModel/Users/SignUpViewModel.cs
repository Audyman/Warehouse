using System.ComponentModel.DataAnnotations;

namespace Warehouse.ViewModel.Users
{
    public class SignUpViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(110)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }

        [Required]
        public bool IsAgreementChecked { get; set; }

        public bool IsAdmin { get; set; }
    }
}