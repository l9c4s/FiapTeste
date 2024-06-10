using Entities.Entidades;



namespace Domain.Interfaces.ITurma
{
    public interface InterfaceTurma
    {
        Task<IList<Turma>> GetallTurmaAsycn();
        Task<bool> AddATurmaAsycn(Turma Turma);
        Task<bool> EditarTurmaAsycn(Turma turma);
        Task<bool> InativarTurmaAsycn(int IdTurma);
    }
}
