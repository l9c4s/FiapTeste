using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Fiap.ModelsDTO.RelacionamentosDTO
{
    public class CreateRelacionamentoDTO
    {
        [Required]
        public int aluno_id { get; set; }
        [Required]
        public int? turma_id { get; set; }
    }
}
