using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IRelacionamentoAlunoTurmasServicos
    {

        Task<bool> AddRelacaoAsync(AlunoTurma alunoTurma);
        Task<IList<RelacionamentoAlunoTurma>> ListaRelacionamentosAsync();
        Task<bool> InativaRelacionamentoAsync(int IdAluno, int IdTurma);
        Task<bool> AtivarRelacionamentoAsync(int IdAluno, int IdTurma);

    }
}
