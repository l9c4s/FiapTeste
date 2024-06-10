using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Aluno
{
    public class EditModel : PageModel
    {

        private readonly IRequest _Request;
        private string errormessage;
        private string successmessage;
        private string edpoint;

        public EditModel(IRequest request)
        {
            _Request = request;
            edpoint = "EditarAluno";
        }



        [BindProperty]
        public AlunoDTO AlunoDto { get; set; } = new AlunoDTO();





        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Aluno/Index");
            }

            var Aluno = _Request.GetByIdAsync<AlunoDTO>("BuscaAlunoPorId", id.Value).GetAwaiter().GetResult();

            if (Aluno == null) {
                Response.Redirect("/Aluno/Index");
            }

            AlunoDto.id = Aluno.id;
            AlunoDto.Nome = Aluno.Nome;
            AlunoDto.Usuario = Aluno.Usuario;
            AlunoDto.Senha = "";
            AlunoDto.Ativo = Aluno.Ativo;

        }

        public void OnPost(int? id) 
        {


            if (id == null)
            {
                Response.Redirect("/Aluno/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errormessage = "Preencha todos os campos";
                return;
            }

            var Aluno = _Request.GetByIdAsync<AlunoDTO>("BuscaAlunoPorId", id.Value).GetAwaiter().GetResult();

            if (Aluno != null)
            {
                Aluno.Nome = AlunoDto.Nome;
                Aluno.Usuario = AlunoDto.Usuario;
                Aluno.Senha = AlunoDto.Senha;
                Aluno.Ativo = AlunoDto.Ativo;

                var RestApi = _Request.PutAsync<AlunoDTO>(Aluno, edpoint).GetAwaiter().GetResult();

                if (RestApi != null)
                {
                    Response.Redirect("/Aluno/Index");
                }

            }


            
        }

    }
}
