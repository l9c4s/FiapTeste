using Dapper;
using Domain.Interfaces.IRelacionamentoAlunoTurma;
using Entities.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SQL.Queires;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RelacionamentoAlunoTurmasRepositorio : InterfaceRelacionamentoAlunoTurmas
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        public RelacionamentoAlunoTurmasRepositorio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> AddRelacaoAsync(AlunoTurma alunoTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(RelacionamentoAlunoTurmaQueries.AddRelacionamento, alunoTurma);

                if (RowsAfetadas > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> AtivarRelacionamentoAsync(int IdAluno, int IdTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(RelacionamentoAlunoTurmaQueries.AtivarRelacao, new { aluno_id = IdAluno, turma_id = IdTurma });

                if (RowsAfetadas > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> InativaRelacionamentoAsync(int IdAluno, int IdTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(RelacionamentoAlunoTurmaQueries.InativarAluno, new { aluno_id = IdAluno, turma_id = IdTurma });

                if (RowsAfetadas > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<IList<RelacionamentoAlunoTurma>> ListaRelacionamentosAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListRelacao = await connection.QueryAsync<RelacionamentoAlunoTurma>(RelacionamentoAlunoTurmaQueries.AllRelaciomento);
                return ListRelacao.ToList();
            }
        }
    }
}
