using System.ComponentModel.DataAnnotations;

namespace StudentMngSystem14_03_26.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email {  get; set; }

        [Required]
        public string Password {  get; set; }

        [Required]
        public string Role {  get; set; }
    }
}
