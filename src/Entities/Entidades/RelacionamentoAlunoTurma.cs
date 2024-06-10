using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class RelacionamentoAlunoTurma : AlunoTurma
    {
        public string turma { get; set; }
        public string curso { get; set; }
        public string Nome { get; set; }
        public int ativo { get; set; }
    }
}
