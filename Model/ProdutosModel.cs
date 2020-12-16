using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crud_cadastro.Model
{
    public class ProdutosModel
    {
        [Key]
        public Guid Produtos_id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required, Range(0,99999.99)]
        public double Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
