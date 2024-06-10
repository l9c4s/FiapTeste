using Entities.Entidades;

namespace Domain.Interfaces.ICurso
{
    public interface InterfaceCurso
    {
        Task<IList<Curso>> ListaCursoAsync();
    }
}
