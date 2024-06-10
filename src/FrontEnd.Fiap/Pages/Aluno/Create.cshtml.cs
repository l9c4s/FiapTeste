using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Fiap.Pages.Aluno
{
    public class CreateModel : PageModel
    {
        private readonly IRequest _Request;
        private string errormessage;
        private string successmessage;
        private string edpoint;

        public CreateModel(IRequest request)
        {
            _Request = request;
            edpoint = "AdicionarAluno";
        }

        [BindProperty]
        public AlunoCreateDTO AlunoDTOGG { get; set; } = new AlunoCreateDTO();


        public void OnGet()
        {
        }


        public void OnPost() {

            if (!ModelState.IsValid)
            {
                errormessage = "Preencha todos os campos";
                return;
            }

            AlunoCreateDTO Alunoinsert = new AlunoCreateDTO();
            Alunoinsert = AlunoDTOGG;

            var RestInsert = _Request.PostAsync<AlunoCreateDTO>(Alunoinsert, edpoint).GetAwaiter().GetResult();

            if (RestInsert != null) {
                Response.Redirect("/Aluno/Index");
            }


            successmessage = "Product Added suceessfully ";
        }
    }
}
