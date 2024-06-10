using FrontEnd.Fiap.ModelsDTO.CursoDTO;
using FrontEnd.Fiap.ModelsDTO.RelacionamentosDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Relacionamento
{
    public class RelacionamentoModel : PageModel
    {
        private readonly IRequest _Request;
        public string errormessage;



        public RelacionamentoModel(IRequest request)
        {
            this._Request = request;
        }

        public int pageIndex = 1;
        public int totalpage = 0;
        private readonly int pageSize = 6;

        //Search
        public string Search = "";
        //sorting
        public string column = "id";
        public string orderBy = "desc";

        [BindProperty]
        public TurmaCreateDTO TurmaDTO { get; set; } = new TurmaCreateDTO();

        [BindProperty]
        public List<CursoDTO> CursoDTO { get; set; } = new List<CursoDTO>();
        [BindProperty]
        public List<RelacionamentoListDTO> RelacionamentoListDTOs { get; set; } = new List<RelacionamentoListDTO>();


        public void OnGet(int? pageIndex, string? Search, string? column, string? orderBy)
        {
            IQueryable<RelacionamentoListDTO> query = _Request.GetAsync<RelacionamentoListDTO>("ListaRelacionamentos").GetAwaiter().GetResult();

            if (Search != null)
            {
                this.Search = Search;
                query = query.Where(p => p.Nome.Contains(Search) || p.curso.Contains(Search));
            }

            string[] validColumn = { "turma", "curso", "nome", "ativo" };
            string[] validOrderBy = { "desc", "asc" };


            if (!validColumn.Contains(column))
            {
                column = "id";
            }

            if (!validOrderBy.Contains(orderBy))
            {
                orderBy = "desc";
            }

            this.orderBy = orderBy;
            this.column = column;



            if (column == "turma")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.turma);
                }
                else
                {
                    query = query.OrderByDescending(p => p.turma);
                }
            }
            else if (column == "curso")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.curso);
                }
                else
                {
                    query = query.OrderByDescending(p => p.curso);
                }
            }
            else if (column == "Nome")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Nome);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Nome);
                }
            }

            else if (column == "ativo")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.ativo);
                }
                else
                {
                    query = query.OrderByDescending(p => p.ativo);
                }
            }

            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            this.pageIndex = (int)pageIndex;


            decimal count = query.Count();
            totalpage = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize).Take(pageSize);
            RelacionamentoListDTOs = query.ToList();

        }


        public IActionResult OnPostInativarRelacao(int? alunoId, int? turmaId)
        {
            if (alunoId == null | turmaId == null)
            {
                return RedirectToPage();

            }


            CreateRelacionamentoDTO createRelacionamentoDTO = new CreateRelacionamentoDTO() { 
             aluno_id = alunoId.Value,
             turma_id = turmaId.Value 
            };    

            var response = _Request.PostAsync<CreateRelacionamentoDTO>(createRelacionamentoDTO, "InativarRelacionamento").GetAwaiter().GetResult();
            if (response != null)
            {
                return RedirectToPage();
            }


            errormessage = "Erro ao tentar inativar, tente novamente";
            OnGet(0, null, null, null);
            return Page();
        }

        public IActionResult OnPostAtivarRelacao(int? alunoId, int? turmaId)
        {
            if (alunoId == null | turmaId == null)
            {
                return RedirectToPage();

            }

            CreateRelacionamentoDTO createRelacionamentoDTO = new CreateRelacionamentoDTO()
            {
                aluno_id = alunoId.Value,
                turma_id = turmaId.Value
            };

            var response = _Request.PostAsync<CreateRelacionamentoDTO>(createRelacionamentoDTO, "AtivarRelacionamento").GetAwaiter().GetResult();
            if (response != null)
            {
                return RedirectToPage();
            }


            errormessage = "Erro ao tentar inativar, tente novamente";
            OnGet(0, null, null, null);
            return Page();
        }
    }
}
