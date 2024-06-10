using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IRelacionamentoAlunoTurma;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class RelacionamentoAlunoTurmaServico : IRelacionamentoAlunoTurmasServicos
    {
        private readonly InterfaceRelacionamentoAlunoTurmas _InterfaceRelacionamentoAlunoTurmas;

        public RelacionamentoAlunoTurmaServico(InterfaceRelacionamentoAlunoTurmas interfaceRelacionamentoAlunoTurmas)
        {
          this._InterfaceRelacionamentoAlunoTurmas = interfaceRelacionamentoAlunoTurmas;
        }

        public async Task<bool> AddRelacaoAsync(AlunoTurma alunoTurma)
        {
            return await _InterfaceRelacionamentoAlunoTurmas.AddRelacaoAsync(alunoTurma);
        }

        public async Task<bool> AtivarRelacionamentoAsync(int IdAluno, int IdTurma)
        {
            return await _InterfaceRelacionamentoAlunoTurmas.AtivarRelacionamentoAsync(IdAluno, IdTurma);
        }

        public async Task<bool> InativaRelacionamentoAsync(int IdAluno, int IdTurma)
        {
            return await _InterfaceRelacionamentoAlunoTurmas.InativaRelacionamentoAsync(IdAluno, IdTurma);
        }

        public async Task<IList<RelacionamentoAlunoTurma>> ListaRelacionamentosAsync()
        {
            return await _InterfaceRelacionamentoAlunoTurmas.ListaRelacionamentosAsync();
        }
    }
}
