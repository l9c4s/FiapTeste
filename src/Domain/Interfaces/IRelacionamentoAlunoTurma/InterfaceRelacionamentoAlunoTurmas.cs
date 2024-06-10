using Entities.Entidades;

namespace Domain.Interfaces.IRelacionamentoAlunoTurma
{
    public interface InterfaceRelacionamentoAlunoTurmas
    {

        Task<bool> AddRelacaoAsync(AlunoTurma alunoTurma); 

        Task<IList<RelacionamentoAlunoTurma>> ListaRelacionamentosAsync();

        Task<bool> InativaRelacionamentoAsync(int IdAluno, int IdTurma);
        Task<bool> AtivarRelacionamentoAsync(int IdAluno, int IdTurma);
        
    }
}
