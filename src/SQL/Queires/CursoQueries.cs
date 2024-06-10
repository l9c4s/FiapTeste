using System.Diagnostics.CodeAnalysis;

namespace SQL.Queires
{
    [ExcludeFromCodeCoverage]
    public class CursoQueries
    {
        public static string AllCursos => "SELECT [id],[nome] FROM [CURSO]";
    }
}
