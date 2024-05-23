using Ecommerce3Ads.Context;
using Ecommerce3Ads.DTO;
using Ecommerce3Ads.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProdutoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return _dataContext.Produto.ToList();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _dataContext.Produto.Find(id).Nome;
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public ActionResult<Produto> Post([FromBody] ProdutoRequest produtoRequest)
        {
            if (ModelState.IsValid) 
            {
                var produto = produtoRequest.toModel();
                _dataContext.Produto.Add(produto);
                _dataContext.SaveChanges();
                return produto;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            var at = _dataContext.Produto.Where(p => p.Id == produto.Id).First();

            if (at == null)
            {
                return BadRequest(ModelState);
            }

            at.Nome = produto.Nome.IsNullOrEmpty() ? at.Nome : produto.Nome;
            at.CategoriaId = produto.CategoriaId == 0 ? at.CategoriaId : produto.CategoriaId;

            _dataContext.SaveChanges();

            return Ok("Produto atualizado com sucesso!");

        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _dataContext.Produto.Find(id);

            if (produto == null)
            {
                ModelState.AddModelError("Id", "Produto não encontrado!");
            }

            if (ModelState.IsValid)
            {
                _dataContext.Produto.Remove(produto);
                _dataContext.SaveChanges();
                return Ok("Produto excluído com sucesso!");
            }

            return BadRequest(ModelState);
        }
    }
}
