using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.ModelsDTO.RelacionamentosDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Fiap.Pages.Relacionamento
{
    public class CreateModel : PageModel
    {
        private readonly IRequest _Request;
        public string errormessage;



        public CreateModel(IRequest request)
        {
            this._Request = request;
        }

        [BindProperty]
        public CreateRelacionamentoDTO CreateRelacDTO { get; set; } = new CreateRelacionamentoDTO();

        public List<SelectListItem> Turmas { get; set; }
        public List<AlunoListByTurmaDTO> alunoDTOs { get; set; }
        public List<AlunoListByTurmaDTO> alunoDTODispoivelParaEsterCurso{ get; set; }
        public int? SelectedTurmaId { get; set; }

        public void OnGet(int? turmaId)
        {
            CarregaTela(turmaId);


        }

        public void OnPost()
        {
            if (CreateRelacDTO.turma_id.HasValue)
            {
                CarregaTela(CreateRelacDTO.turma_id);
                Page();
            }
            else {
                OnGet(null);
            }

            if (CreateRelacDTO.aluno_id != 0 && CreateRelacDTO.turma_id != 0)
            {
                CreateRelacionamentoDTO RelacInsert = CreateRelacDTO;
                var RestApi = _Request.PostAsync<CreateRelacionamentoDTO>(RelacInsert, "AddRelacionamento").GetAwaiter().GetResult();
                if (RestApi != null)
                {

                    Response.Redirect("/Relacionamento/Index");
                }
            }
            
        }


        public void CarregaTela(int? turmaId)
        {
            IQueryable<TurmaListDTO> query = _Request.GetAsync<TurmaListDTO>("ListaTurma").GetAwaiter().GetResult();
            Turmas = query.Select(t => new SelectListItem
            {
                Value = t.id.ToString(),
                Text = t.Turma
            }).ToList();

            if (turmaId.HasValue)
            {
                SelectedTurmaId = turmaId.Value;
                alunoDTOs = _Request.PostWithIdAsync<List<AlunoListByTurmaDTO>>(turmaId.Value, "BuscaAlunoPorIdTurma").GetAwaiter().GetResult();
                alunoDTODispoivelParaEsterCurso = _Request.PostWithIdAsync<List<AlunoListByTurmaDTO>>(turmaId.Value, "BuscaAlunosDisponivelTurma").GetAwaiter().GetResult();

            }

        }

    }
}
