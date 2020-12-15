using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crud_cadastro.Model
{
    public class ProdutosModel
    {
        public Guid Produtos_id { get; set; }
        public string Descricao { get; set; }
        [Range(0,00000.00)]
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
