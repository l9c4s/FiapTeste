using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.ModelsDTO.CursoDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Turma
{
    public class CreateModel : PageModel
    {

        private readonly IRequest _Request;
        public string errormessage;
        public string successmessage;
        private string edpoint;

        public CreateModel(IRequest request)
        {
            _Request = request;
            edpoint = "AdicionarTurma";
        }

        [BindProperty]
        public TurmaCreateDTO TurmaDTO { get; set; } = new TurmaCreateDTO();

        [BindProperty]
        public List<CursoDTO> CursoDTO { get; set; } = new List<CursoDTO>();


        public void OnGet()
        {

            LoadCurso();
        }

        public void OnPost() {

            if (!ModelState.IsValid)
            {
                errormessage = "Preecha todos os campos!!";
                LoadCurso();
                return;
            }
            bool NomeExiste = _Request.PostAsyncBool(TurmaDTO.Turma, "VerificarNomeTurma").GetAwaiter().GetResult();

            if (NomeExiste) {

                errormessage = "Ja existe turma com esse nome";
                LoadCurso();
                return;
            }

            TurmaCreateDTO TurmaInsert = new TurmaCreateDTO();
            TurmaInsert = TurmaDTO;

            var RestInsert = _Request.PostAsync<TurmaCreateDTO>(TurmaInsert, edpoint).GetAwaiter().GetResult();

            if (RestInsert == null)
            {
                errormessage = "Erro ao tentar cadastrar a nova turma tente novamente";
                LoadCurso();
                return;
            }

            Response.Redirect("/Turma/Index");

        }
        
        private void LoadCurso()
        {
            IQueryable<CursoDTO> ListaDeCursos = _Request.GetAsync<CursoDTO>("ListaCurso").GetAwaiter().GetResult();
            CursoDTO = ListaDeCursos.ToList();

        }
    }
}
