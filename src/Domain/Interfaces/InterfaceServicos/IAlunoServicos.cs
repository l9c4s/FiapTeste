
using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IAlunoServicos
    {
        Task<IList<Aluno>> GetallAlunosAsycn();
        Task<IList<Aluno>> BuscaAlunoPorIdTurmaAsync(int IdTurma);
        Task<IList<Aluno>> BuscaAlunoDisponivelIdTurmaAsync(int IdTurma);

        Task<bool> InativarAlunoAsycn(int IdAluno);

        Task<bool> AddAlunoAsycn(Aluno aluno);

        Task<bool> EditarAluno(Aluno aluno); 

    }
}
