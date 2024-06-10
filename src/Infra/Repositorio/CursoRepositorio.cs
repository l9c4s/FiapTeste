using Dapper;
using Domain.Interfaces.ICurso;
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
    public class CursoRepositorio : InterfaceCurso
    {

        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        public CursoRepositorio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IList<Curso>> ListaCursoAsync()
        {

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var ListaCurso = await connection.QueryAsync<Curso>(CursoQueries.AllCursos);
                return ListaCurso.ToList();
            }
        }
    }
}
