using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_cadastro.Model
{
    public class PessoasModel
    {
        [Key]
        public Guid Pessoas_id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Cidade { get; set; }

    }
}
