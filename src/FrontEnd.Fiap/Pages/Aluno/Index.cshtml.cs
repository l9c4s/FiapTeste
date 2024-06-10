using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Aluno
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

        public List<AlunoDTO> alunoDTOs { get; set; } = new List<AlunoDTO>();


        public void OnGet(int? pageIndex, string? Search, string? column, string? orderBy)
        {
            IQueryable<AlunoDTO> query = _Request.GetAsync<AlunoDTO>("ListaAluno").GetAwaiter().GetResult();

            if (Search != null)
            {
                this.Search = Search;
                query = query.Where(p => p.Nome.Contains(Search) || p.Usuario.Contains(Search));
            }

            string[] validColumn = { "id", "Nome", "Usuario", "Ativo" };
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
            else if (column == "Usuario")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Usuario);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Usuario);
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
            alunoDTOs = query.ToList();
        }

        public void OnPost(int? id)
        {
            if(id != null)
            {
                var rest = _Request.PostAsync<int>(id.Value, "InativarAluno").GetAwaiter().GetResult();

                if (rest != null)
                {
                    Response.Redirect("/Aluno/Index");
                }

            }





        }
    }
}
