using FrontEnd.Fiap.ModelsDTO.AlunoDTO;
using FrontEnd.Fiap.ModelsDTO.TurmaDTO;
using FrontEnd.Fiap.Request.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace FrontEnd.Fiap.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRequest _request;

        public IndexModel(ILogger<IndexModel> logger, IRequest request )
        {
            this._request = request;
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
