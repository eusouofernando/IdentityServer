using System.ComponentModel.DataAnnotations;

namespace IdentityServer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password confirmation doesn't match Password")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
