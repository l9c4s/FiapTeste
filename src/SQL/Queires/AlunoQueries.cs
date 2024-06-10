using System.Diagnostics.CodeAnalysis; 

namespace SQL.Queires
{
    [ExcludeFromCodeCoverage]
    public static class AlunoQueries
    {
        public static string AllAluno => "SELECT [id],[nome],[usuario],[Ativo] FROM [ALUNO]";

        public static string AllAlunoWithPass => "SELECT [id],[senha],[nome],[usuario],[Ativo] FROM [ALUNO]"; 

        public static string AddAluno =>
            @"INSERT INTO [ALUNO]( [nome], [usuario], [senha]) 
				VALUES (@nome, @usuario, @senha)";

        public static string UpdateAluno =>
            @"UPDATE [ALUNO] 
            SET [nome] = @Nome, 
				[usuario] = @Usuario, 
				[senha] = @Senha,
                [Ativo] = @ativo
            WHERE [id] = @id";

        public static string InativarAluno =>
            @"UPDATE [ALUNO] 
            SET [Ativo] = 0
            WHERE [aluno_id] = @aluno_id 
            AND [turma_id]= @turma_id";

        public static string BuscarAlunosPorTurma =>
        @"SELECT AL.nome , tm.ativo  FROM ALUNO AL
                INNER JOIN ALUNO_TURMA TM on AL.id = tm.aluno_id 
                WHERE tm.turma_id  = @turma_id";

        public static string ListarAlunosDisponivelPorTurma =>
            @"SELECT A.id , a.nome  FROM ALUNO A
                     WHERE NOT EXISTS ( SELECT 1 FROM ALUNO_TURMA
                    WHERE aluno_id = A.id AND turma_id = @turma_id
                )";



    }
}
