namespace FrontEnd.Fiap.ModelsDTO.TurmaDTO
{
    public class TurmaListDTO
    {

        public int? id { get; set; }
        public int? Curso_id { get; set; }

        public string? CursoDesc { get; set; }

        public string? Turma { get; set; }

        public DateTime? Ano { get; set; }

        public int? Ativo { get; set; }
    }
}
