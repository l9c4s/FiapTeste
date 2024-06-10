using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ITurmaServicos
    {
        Task<Turma> BuscaTurmaPorIdAsync(int id);
        Task<bool> VerificaNomeTurmaAsync(string Nome);
        Task<bool> AddTurmaAsycn(Turma Turma);
        Task<bool> EditarTurma(Turma Turma);
        Task<IList<Turma>> GetallTurmaAsycn();
        public Task<bool> InativarTurmaAsycn(int IdTurma);
    }
}
