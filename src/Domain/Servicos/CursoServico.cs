using Domain.Interfaces.IAluno;
using Domain.Interfaces.ICurso;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class CursoServico : ICursoServicos
    {
        private readonly InterfaceCurso _interfaceCurso;

        public CursoServico(InterfaceCurso interfaceServicos, InterfaceAluno interfaceAluno)
        {
            this._interfaceCurso = interfaceServicos;
        }


        public async Task<IList<Curso>> ListaCursoAsync()
        {

            return await _interfaceCurso.ListaCursoAsync();
        }
    }
}
