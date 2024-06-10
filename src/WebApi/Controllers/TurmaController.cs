using Microsoft.AspNetCore.Mvc;
using Entities.Entidades;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IAluno;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaServicos _InterafaceTurma;

        public TurmaController(ITurmaServicos Interfaceturma)
        {
            _InterafaceTurma = Interfaceturma;
        }

        [HttpGet("/api/ListaTurma")]
        [Produces("application/json")]
        public async Task<object> ListaTurma()
        {
            return await _InterafaceTurma.GetallTurmaAsycn();
        }

        [HttpPost("/api/AdicionarTurma")]
        [Produces("application/json")]
        public async Task<object> AdicionarTurma([FromBody]Turma Turma)
        {
            return await _InterafaceTurma.AddTurmaAsycn(Turma);
        }

        [HttpPut("/api/EditarTurma")]
        [Produces("application/json")]
        public async Task<object> EditarTurma([FromBody]Turma Turma)
        {
            return await _InterafaceTurma.EditarTurma(Turma);
        }

        [HttpPost("/api/VerificarNomeTurma")]
        [Produces("application/json")]
        public async Task<object> VerificarNomeTurma([FromBody] string Turma)
        {
            return await _InterafaceTurma.VerificaNomeTurmaAsync(Turma);
        }

        [HttpPost("/api/BuscaTurmaPorId")]
        [Produces("application/json")]
        public async Task<object> BuscaTurmaPorId([FromBody] int Turmaid)
        {
            return await _InterafaceTurma.BuscaTurmaPorIdAsync(Turmaid);

        }

        [HttpPost("/api/InativarTurma")]
        [Produces("application/json")]
        public async Task<object> InativarTurma([FromBody] int Turma)
        {
            return await _InterafaceTurma.InativarTurmaAsycn(Turma);
        }

    }
}
