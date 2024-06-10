using Domain.Interfaces.IAluno;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Servicos
{
    public class AlunoServico : IAlunoServicos
    {
        private readonly InterfaceAluno _interfaceServicos;
        public AlunoServico(InterfaceAluno interfaceServicos)
        {
            this._interfaceServicos = interfaceServicos;
        }
        public async Task<bool> AddAlunoAsycn(Aluno aluno)
        {
            Aluno aluno1 = aluno;
            aluno1.Senha = Hash(aluno.Senha);

            return await _interfaceServicos.AddAlunoAsycn(aluno1);
        }
        public async Task<bool> EditarAluno(Aluno aluno)
        {
            var EditAluno = await _interfaceServicos.GetAlunoWithPassAsync(aluno.id.Value);

            if (EditAluno != null) {
                 

                if (aluno.Senha != null)
                {
                    if (!EditAluno.Senha.Equals(Hash(aluno.Senha)))
                    {
                        EditAluno.Senha = Hash(aluno.Senha);
                    }
                   
                }

                EditAluno.Usuario = aluno.Usuario;
                EditAluno.Ativo = aluno.Ativo;
                EditAluno.Nome = aluno.Nome;
                return await _interfaceServicos.EditarAluno(EditAluno);
            }

            return false;
        }
        public async Task<IList<Aluno>> GetallAlunosAsycn()
        {
            return await _interfaceServicos.GetallAlunosAsycn();
        }
        public async Task<bool> InativarAlunoAsycn(int IdAluno)
        {
            return await _interfaceServicos.InativarAlunoAsycn(IdAluno);
        }
        public async Task<IList<Aluno>> BuscaAlunoPorIdTurmaAsync(int IdTurma)
        {
            return await _interfaceServicos.BuscaAlunoPorIdTurmaAsync(IdTurma);
        }
        public async Task<IList<Aluno>> BuscaAlunoDisponivelIdTurmaAsync(int IdTurma)
        {
            return await _interfaceServicos.BuscaAlunoDisponivelIdTurmaAsync(IdTurma);
        }






        private static string Hash(string Senha)
        {
            // Cria uma instância de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computa o hash da string fornecida
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Senha));

                // Converte o array de bytes para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

      
    }
}
