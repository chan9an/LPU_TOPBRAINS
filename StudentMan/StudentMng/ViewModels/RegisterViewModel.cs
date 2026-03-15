using System.ComponentModel.DataAnnotations;

namespace StudentMngSystem14_03_26.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
