using System.ComponentModel.DataAnnotations;

namespace RunGroupWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password confirmation does not match")]
        public string ConfirmPassword { get; set; }
    }
}
