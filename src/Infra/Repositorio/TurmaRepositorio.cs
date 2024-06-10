using Dapper;
using Domain.Interfaces.ITurma;
using Entities.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SQL.Queires;
using System.Data;




namespace Infra.Repositorio
{
    public class TurmaRepositorio : InterfaceTurma
    {

        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        public TurmaRepositorio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }




        public async Task<bool> AddATurmaAsycn(Turma aluno)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(TurmaQueries.AddTurma, aluno);

                if (RowsAfetadas > 0) { 
                    return true;
                }
                return false;

            }
        }

        public async Task<bool> EditarTurmaAsycn(Turma Turma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(TurmaQueries.UpdateTurma, Turma);

                if (RowsAfetadas > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<IList<Turma>> GetallTurmaAsycn()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaTurma = await connection.QueryAsync<Turma>(TurmaQueries.AllTurma);
                return ListaTurma.ToList();
            }
        }

        public async Task<bool> InativarTurmaAsycn(int IdTurma)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int RowsAfetadas = await connection.ExecuteAsync(TurmaQueries.InativarTurma, new { Id = IdTurma });
            
                if (RowsAfetadas > 0) { 
                    return true; 
                }
                return false;
            
            }
        }
    }
}
