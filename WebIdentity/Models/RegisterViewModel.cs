using System.ComponentModel.DataAnnotations;

namespace WebIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirma a Senha")]
        [Compare("Password", ErrorMessage ="As Senhas não Conferem")]
        public string? confirmPassword { get; set; }
    }
}
