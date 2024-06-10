using Domain.Interfaces.IAluno;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IAlunoServicos _interfaceAluno;

        public AlunoController(IAlunoServicos interfaceAluno)
        {
            _interfaceAluno = interfaceAluno;
        }

        [HttpPost("/api/BuscaAlunosDisponivelTurma")]
        [Produces("application/json")]
        public async Task<object> BuscaAlunosDisponivelTurma([FromBody] int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Nulo");
            }

            var alunos = await _interfaceAluno.BuscaAlunoDisponivelIdTurmaAsync(id.Value);


            return alunos;
        }



        [HttpPost("/api/BuscaAlunoPorIdTurma")]
        [Produces("application/json")]
        public async Task<object> BuscaAlunoPorIdTurma([FromBody] int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Nulo");
            }

            var alunos = await _interfaceAluno.BuscaAlunoPorIdTurmaAsync(id.Value);


            return alunos;
        }

        [HttpPost("/api/BuscaAlunoPorId")]
        [Produces("application/json")]
        public async Task<object> BuscaAlunoPorId([FromBody] int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Nulo");
            }

            var ListaAluno = await _interfaceAluno.GetallAlunosAsycn();
            Aluno aluno = ListaAluno.FirstOrDefault(x => x.id.Equals(id));

            if (aluno == null)
            {

                return BadRequest("not found");
            }

            return aluno;
        }


        [HttpGet("/api/ListaAluno")]
        [Produces("application/json")]
        public async Task<object> ListaAlunos()
        {
            return await _interfaceAluno.GetallAlunosAsycn();
        }

        [HttpPost("/api/AdicionarAluno")]
        [Produces("application/json")]
        public async Task<object> AdicionarAluno([FromBody]Aluno aluno)
        {
            return await _interfaceAluno.AddAlunoAsycn(aluno);
        }

        [HttpPut("/api/EditarAluno")]
        [Produces("application/json")]
        public async Task<object> EditarAluno(Aluno aluno)
        {
            return await _interfaceAluno.EditarAluno(aluno);
        }

        [HttpPost("/api/InativarAluno")]
        [Produces("application/json")]
        public async Task<object> InativarAluno([FromBody] int? IdAluno)
        {
            if (IdAluno.Value == null)
            {
                return BadRequest("Id Nulo");
            }


            return await _interfaceAluno.InativarAlunoAsycn(IdAluno.Value);
        }
    }
}
