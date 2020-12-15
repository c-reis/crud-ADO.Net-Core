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
            ProdutoData.Update(produto);
            return Ok(produto);
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
            var busca = ProdutoData.Seach();
            return Ok(busca);
        }

        [HttpGet]
        [Route("SearchById")]
        public ActionResult SearchById(Guid produto_id)
        {
            var busca = ProdutoData.SearchById(produto_id);
            return Ok(busca);
        }
    }
}
