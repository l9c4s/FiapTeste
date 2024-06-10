using Entities.Entidades;

namespace Domain.Interfaces.IAluno
{
    public interface InterfaceAluno
    {
        Task<bool> AddAlunoAsycn(Aluno aluno);
        Task<IList<Aluno>> BuscaAlunoPorIdTurmaAsync(int IdTurma);
        Task<IList<Aluno>> BuscaAlunoDisponivelIdTurmaAsync(int IdTurma);
        Task<bool> EditarAluno(Aluno aluno);
        Task<IList<Aluno>> GetallAlunosAsycn();
        Task<bool> InativarAlunoAsycn(int IdAluno);
        Task<Aluno> GetAlunoWithPassAsync(int Id);
        
    }
}
