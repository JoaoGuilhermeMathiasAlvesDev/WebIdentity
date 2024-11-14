using System.ComponentModel.DataAnnotations;

namespace WebIdentity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O email é obrigatorio")]
        [EmailAddress (ErrorMessage ="Email Invalido")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="A senhar e obrigatoria")]
        [DataType(DataType.Password)]
        public string?  Passaword { get; set; }

        [Display(Name = "Lambrar - me")]
        public bool RemeberMe { get; set; }
    }
}
