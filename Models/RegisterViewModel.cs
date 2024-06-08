using System.ComponentModel.DataAnnotations;

namespace AsystentKonserwacji.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie pasują.")]
        public string ConfirmPassword { get; set; }
    }
}
