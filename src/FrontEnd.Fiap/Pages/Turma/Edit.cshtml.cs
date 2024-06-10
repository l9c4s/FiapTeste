using FrontEnd.Fiap.ModelsDTO.CursoDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Turma
{
    public class EditModel : PageModel
    {
        private readonly IRequest _Request;
        public string errormessage;
        private string edpoint;

        public EditModel(IRequest request)
        {
            _Request = request;
            edpoint = "EditarTurma";
        }


        [BindProperty]
        public TurmaCreateDTO TurmaDTO { get; set; } = new TurmaCreateDTO();

        [BindProperty]
        public List<CursoDTO> CursoDTO { get; set; } = new List<CursoDTO>();

        public void OnGet(int? Id)
        {
            if (Id == null)
            {
                Response.Redirect("/Turma/Index");
            }
            var TurmaEdit = _Request.GetByIdAsync<TurmaCreateDTO>("BuscaTurmaPorId",Id.Value).GetAwaiter().GetResult();
            if (TurmaEdit != null) {
                TurmaDTO = TurmaEdit;
            }
            LoadCurso();

        }

        public void OnPost(int? id)
        {

            if (id == null)
            {
                Response.Redirect("/Aluno/Index");
            }

            if (!ModelState.IsValid)
            {
                errormessage = "Preencha todos os campos";
                return;
            }

            var TurmaEdit = _Request.GetByIdAsync<TurmaCreateDTO>("BuscaTurmaPorId", id.Value).GetAwaiter().GetResult();
 
                if (TurmaEdit != null)
                {
                    if (!TurmaEdit.Turma.Equals(TurmaDTO.Turma, StringComparison.OrdinalIgnoreCase))
                    {
                        bool NomeExiste = _Request.PostAsyncBool(TurmaDTO.Turma, "VerificarNomeTurma").GetAwaiter().GetResult();
                        if (NomeExiste)
                        {
                            errormessage = "Ja existe turma com esse nome";
                            LoadCurso();
                            return;
                        }
                    }

                    var rest = _Request.PutAsync<TurmaCreateDTO>(TurmaEdit, edpoint).GetAwaiter().GetType();
                    if (rest != null)
                    {
                        Response.Redirect("/Aluno/Index");
                    }
                }

                TurmaEdit = TurmaDTO;

                var RestApi = _Request.PutAsync<TurmaCreateDTO>(TurmaEdit,edpoint).GetAwaiter().GetResult();

                if (RestApi != null) {
                    Response.Redirect("/Turma/Index");
                }

                errormessage = "Erro ao editar, Tente Novamente";
                LoadCurso();
                return;

            LoadCurso();
            errormessage = "Erro ao editar, Tente Novamente";
            return;
        }

        private void LoadCurso()
        {
            IQueryable<CursoDTO> ListaDeCursos = _Request.GetAsync<CursoDTO>("ListaCurso").GetAwaiter().GetResult();
            CursoDTO = ListaDeCursos.ToList();

        }
    }
}
