using Dapper;
using Domain.Interfaces.IAluno;
using Entities.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using SQL.Queires;


namespace Infra.Repositorio
{
    public class AlunoRepositorio : InterfaceAluno
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        public AlunoRepositorio (IConfiguration configuration)
        {
            this.configuration = configuration;
        }




        public async Task<bool> AddAlunoAsycn(Aluno aluno)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            { 
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(AlunoQueries.AddAluno, aluno);

                if (RowsAfetadas > 0) { 
                    return true;
                }

                return false;
            }
        }

        public async Task<IList<Aluno>> BuscaAlunoDisponivelIdTurmaAsync(int IdTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaAluno = await connection.QueryAsync<Aluno>(AlunoQueries.ListarAlunosDisponivelPorTurma, new { turma_id = IdTurma });
                return ListaAluno.ToList();
            }
        }

        public async Task<IList<Aluno>> BuscaAlunoPorIdTurmaAsync(int IdTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaAluno = await connection.QueryAsync<Aluno>(AlunoQueries.BuscarAlunosPorTurma, new { turma_id = IdTurma });
                return ListaAluno.ToList();
            }
        }

        public async Task<bool> EditarAluno(Aluno aluno)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(AlunoQueries.UpdateAluno, aluno);

                if (RowsAfetadas > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<IList<Aluno>> GetallAlunosAsycn()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaAluno = await connection.QueryAsync<Aluno>(AlunoQueries.AllAluno);
                return ListaAluno.ToList();
            }
        }

        public async Task<Aluno> GetAlunoWithPassAsync(int Id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaAluno = await connection.QueryAsync<Aluno>(AlunoQueries.AllAlunoWithPass);
                Aluno retorno = ListaAluno.FirstOrDefault(x => x.id.Equals(Id));
                return retorno;
            }
        }

        public async Task<bool> InativarAlunoAsycn(int IdAluno)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(AlunoQueries.InativarAluno, new { Id =  IdAluno });

                if (RowsAfetadas > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
