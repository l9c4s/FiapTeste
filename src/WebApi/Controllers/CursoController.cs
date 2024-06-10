using Domain.Interfaces.InterfaceServicos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoServicos _interfaceCurso;

        public CursoController(ICursoServicos CursoServicos)
        {
            this._interfaceCurso = CursoServicos;
        }



        [HttpGet("/api/ListaCurso")]
        [Produces("application/json")]
        public async Task<object> ListaCurso()
        {
            return await _interfaceCurso.ListaCursoAsync();
        }
    }
}
