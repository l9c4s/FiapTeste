using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Fiap.ModelsDTO.TurmaDTO
{
    public class TurmaCreateDTO
    {
        public int? id { get; set; }

        public int? Curso_id { get; set; }

        [Required(ErrorMessage = "O nome da turma é obrigatório.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 a 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]{2,20}$", ErrorMessage = "O nome deve conter apenas letras e ter entre 2 a 20 caracteres.")]
        public string? Turma { get; set; }


        [Required(ErrorMessage = "Escolha uma Data")]
        public DateTime? Ano { get; set; }

        public int? Ativo { get; set; }
    }
}
