using crud_cadastro.Data;
using crud_cadastro.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_cadastro.Controllers
{
    [Route("cadastro/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private ProdutoData ProdutoData { get; set; }

        public ProdutoController (ProdutoData produtoData)
        {
            ProdutoData = produtoData;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProdutosModel produto)
        {
            Guid idNewGuid = Guid.NewGuid();
            produto.Produtos_id = idNewGuid;
            ProdutoData.Create(produto);
            return NoContent();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(ProdutosModel produto)
        {
            var retorno = ProdutoData.Update(produto);
            return Ok(retorno);
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Guid produto_id)
        {
            ProdutoData.Delete(produto_id);
            return NoContent();
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search()
        {
            var search = ProdutoData.Seach();
            return Ok(search);
        }

        [HttpGet]
        [Route("SearchById")]
        public ActionResult SearchById(Guid produto_id)
        {
            var searchById = ProdutoData.SearchById(produto_id);
            return Ok(searchById);
        }

        [HttpGet]
        [Route("SearchByWords")]
        public ActionResult SearchByWords(string words)
        {
            var searchByWords = ProdutoData.SearchByWords(words);
            return Ok(searchByWords);
        }
    }
}
