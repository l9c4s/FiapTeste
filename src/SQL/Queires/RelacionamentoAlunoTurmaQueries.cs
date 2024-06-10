namespace SQL.Queires
{
    public class RelacionamentoAlunoTurmaQueries
    {
        public static string AddRelacionamento =>
            @"INSERT INTO [ALUNO_TURMA]( [aluno_id], [turma_id]) 
				VALUES (@aluno_id, @turma_id)";

        public static string AllRelaciomento => "SELECT at2.aluno_id,at2.turma_id, T.turma,c.nome as curso ,a.nome , at2.ativo  " +
            "FROM ALUNO_TURMA at2 INNER JOIN TURMA t ON at2.turma_id = T.id " +
            "INNER JOIN CURSO c ON T.curso_id = c.id " +
            "INNER JOIN ALUNO a ON at2.aluno_id = A.id;";

        public static string InativarAluno =>
            @"UPDATE [ALUNO_TURMA] 
            SET [ativo] = 0
            WHERE [aluno_id] = @aluno_id 
            AND [turma_id] = @turma_id";
        public static string AtivarRelacao =>
            @"UPDATE [ALUNO_TURMA] 
            SET [ativo] = 1
            WHERE [aluno_id] = @aluno_id 
            AND [turma_id] = @turma_id";

    }
}
