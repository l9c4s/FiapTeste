using Entities.Entidades;


namespace Domain.Interfaces.InterfaceServicos
{
    public interface ICursoServicos
    {
        Task<IList<Curso>> ListaCursoAsync();
    }
}
