using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ITurma;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class TurmaServico : ITurmaServicos
    {
        private readonly InterfaceTurma _interfaceTurma;

        public TurmaServico(InterfaceTurma interfaceTurma)
        {
            this._interfaceTurma = interfaceTurma;
        }

        public async Task<bool> AddTurmaAsycn(Turma Turma)
        {
            return await _interfaceTurma.AddATurmaAsycn(Turma);
        }

        public async Task<bool> EditarTurma(Turma Turma)
        {
            return await _interfaceTurma.EditarTurmaAsycn(Turma);
        }

        public async Task<IList<Turma>> GetallTurmaAsycn()
        {
            return await _interfaceTurma.GetallTurmaAsycn();
        }

        public async Task<bool> InativarTurmaAsycn(int IdTurma)
        {
            return await _interfaceTurma.InativarTurmaAsycn(IdTurma);
        }

        public async Task<bool> VerificaNomeTurmaAsync(string Nome)
        {
            IList<Turma> turmas = await this.GetallTurmaAsycn();
            return  VerificaSeContenTurma(turmas, Nome);
        }
        public async Task<Turma> BuscaTurmaPorIdAsync(int id)
        {
           var ListaTurma = await this.GetallTurmaAsycn();

            return ListaTurma.FirstOrDefault(x => x.id.Equals(id));
        }

        public static bool VerificaSeContenTurma(IList<Turma> turmas, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return false;
            }

            return turmas.Any(t => !string.IsNullOrEmpty(t.turma) && searchString.Contains(t.turma, StringComparison.OrdinalIgnoreCase));
        }

       
    }
}
