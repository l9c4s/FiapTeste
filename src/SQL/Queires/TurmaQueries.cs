using System.Diagnostics.CodeAnalysis;



namespace SQL.Queires
{
    [ExcludeFromCodeCoverage]
    public class TurmaQueries
    {
        public static string AllTurma=> "SELECT [id],[curso_id],[turma],[ano],[Ativo] FROM [TURMA]";

        public static string AddTurma =>
            @"INSERT INTO [TURMA]( [curso_id], [turma], [ano]) 
				VALUES (@Curso_id, @turma, @Ano)";

        public static string UpdateTurma =>
            @"UPDATE [TURMA] 
            SET [turma] = @turma,
                [Curso_id] = @Curso_id,
				[ano] = @Ano,
                [Ativo] = @Ativo
            WHERE [id] = @id";

        public static string InativarTurma =>
              @"UPDATE [TURMA] 
            SET [Ativo] = 0
            WHERE [id] = @id";


    }
}
