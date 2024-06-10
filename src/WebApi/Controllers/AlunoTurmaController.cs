using Domain.Interfaces.ICurso;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IRelacionamentoAlunoTurmasServicos _relacionamentoAlunoTurmasServicos;
        public AlunoTurmaController(IRelacionamentoAlunoTurmasServicos relacionamentoAlunoTurmasServicos) {

            this._relacionamentoAlunoTurmasServicos = relacionamentoAlunoTurmasServicos;
        }

        [HttpPost("/api/AddRelacionamento")]
        [Produces("application/json")]
        public async Task<object> AddRelacionamento([FromBody] AlunoTurma alunoTurma)
        {
            return await _relacionamentoAlunoTurmasServicos.AddRelacaoAsync(alunoTurma);
        }

        [HttpPost("/api/AtivarRelacionamento")]
        [Produces("application/json")]
        public async Task<object> AtivarRelacionamento([FromBody] AlunoTurma alunoTurma)
        {
            return await _relacionamentoAlunoTurmasServicos.AtivarRelacionamentoAsync(alunoTurma.aluno_id, alunoTurma.turma_id);
        }

        [HttpPost("/api/InativarRelacionamento")]
        [Produces("application/json")]
        public async Task<object> InativarRelacionamento([FromBody] AlunoTurma alunoTurma)
        {
            return await _relacionamentoAlunoTurmasServicos.InativaRelacionamentoAsync(alunoTurma.aluno_id, alunoTurma.turma_id);
        }
        [HttpGet("/api/ListaRelacionamentos")]
        [Produces("application/json")]
        public async Task<object> ListaRelacionamentos()
        {
            return await _relacionamentoAlunoTurmasServicos.ListaRelacionamentosAsync();
        }
    }
}
