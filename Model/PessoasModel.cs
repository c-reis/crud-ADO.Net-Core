using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_cadastro.Model
{
    public class PessoasModel
    {
        public Guid Pessoas_id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }

    }
}
