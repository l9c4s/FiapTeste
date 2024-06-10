using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.ModelsDTO.CursoDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Turma
{
    public class IndexModel : PageModel
    {
        private readonly IRequest _Request;


        public IndexModel(IRequest request)
        {
            _Request = request;
        }

        public int pageIndex = 1;
        public int totalpage = 0;
        private readonly int pageSize = 6;

        //Search
        public string Search = "";
        //sorting
        public string column = "id";
        public string orderBy = "desc";

        public List<TurmaListDTO> turmaDTOs { get; set; } = new List<TurmaListDTO>();


        public void OnGet(int? pageIndex, string? Search, string? column, string? orderBy)
        {
            IQueryable<TurmaListDTO> query = _Request.GetAsync<TurmaListDTO>("ListaTurma").GetAwaiter().GetResult();
            IQueryable<CursoDTO> ListaDeCursos = _Request.GetAsync<CursoDTO>("ListaCurso").GetAwaiter().GetResult();

            query = from turma in query
                    join curso in ListaDeCursos on turma.Curso_id equals curso.Id
                    select new TurmaListDTO
                    {
                        id = turma.id,
                        Curso_id = curso.Id,
                        CursoDesc = curso.Nome,
                        Turma = turma.Turma,
                        Ano = turma.Ano,
                        Ativo = turma.Ativo,
                    };


            if (Search != null)
            {
                this.Search = Search;
                query = query.Where(p => p.Turma.Contains(Search));
            }

            string[] validColumn = { "id", "Turma", "CursoDesc", "Ano","Ativo" };
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


            if (column == "id")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.id);
                }
                else
                {
                    query = query.OrderByDescending(p => p.id);
                }
            }
            else if (column == "Turma")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Turma);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Turma);
                }
            }
            else if (column == "CursoDesc")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.CursoDesc);
                }
                else
                {
                    query = query.OrderByDescending(p => p.CursoDesc);
                }
            }
            else if (column == "Ano")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Ano);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Ano);
                }
            }
            else if (column == "Ativo")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Ativo);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Ativo);
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
            turmaDTOs = query.ToList();
        }


        public void OnPost(int? id)
        { 
            if (id != null)
            {
                var rest = _Request.PostAsync<int>(id.Value, "InativarTurma").GetAwaiter().GetResult();

                if (rest != null)
                {
                    Response.Redirect("/Turma/Index");
                }

            }







        }
    }
}
