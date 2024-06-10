using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Fiap.ModelsDTO.AlunoDTO
{
    public class AlunoCreateDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 a 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z ]{5,20}$", ErrorMessage = "O nome deve conter apenas letras e ter entre 5 a 20 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Usuario é obrigatório.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O Usuario deve ter entre 5 a 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z ]{5,20}$", ErrorMessage = "O Usuario deve conter apenas letras e ter entre 5 a 20 caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?""{}|<>]).{8,}$",
        ErrorMessage = "A senha deve ter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula, um dígito e um caractere especial.")]
        public string Senha { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
