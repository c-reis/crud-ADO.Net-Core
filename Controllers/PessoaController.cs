using crud_cadastro.Data;
using crud_cadastro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_cadastro.Controllers
{
    [Route("cadastro/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private PessoaData PessoaData { get; set; }

        public PessoaController(PessoaData pessoaData)
        {
            PessoaData = pessoaData;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(PessoasModel pessoa)
        {
            Guid idNewGuid = Guid.NewGuid();
            pessoa.Pessoas_id = idNewGuid;
            PessoaData.Create(pessoa);
            return NoContent();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(PessoasModel pessoa)
        {
            PessoaData.Update(pessoa);
            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Guid id)
        {
            PessoaData.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search()
        {
            var busca = PessoaData.Search();
            return Ok(busca);
        }

        [HttpGet]
        [Route("SearchById")]
        public ActionResult SearchbyId(Guid pessoas_id)
        {
            var busca = PessoaData.SearchbyId(pessoas_id);
            return Ok(busca);
        }
    }
}
