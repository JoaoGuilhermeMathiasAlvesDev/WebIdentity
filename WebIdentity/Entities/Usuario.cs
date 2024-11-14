using System.ComponentModel.DataAnnotations;

namespace WebIdentity.Entities
{
    public class Usuario : EntityBase.EntityBase
    {
        [Required, MaxLength(80, ErrorMessage ="Não me nao pode ser maior que 80 caracteres")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required,MaxLength(120)]
        public string Email { get; set; }

        public int Idade {  get; set; }

    }
}
