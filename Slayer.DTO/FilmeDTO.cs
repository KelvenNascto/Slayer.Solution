using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slayer.DTO
{
    public class FilmeDTO
    {
        public int IdFilme { get; set; }
        public string TituloFilme { get; set; }
        public string ProdutoraFilme { get; set; }
        public string UrlFilme { get; set; }


        public string GeneroId { get; set; }
        public string ClassificacaoId { get; set; }

    }
}
