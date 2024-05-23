using Ecommerce3Ads.Context;
using Ecommerce3Ads.DTO;
using Ecommerce3Ads.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly DataContext _dataContext;

        //public CategoriasController()
        //{
        //    _dataContext = new DataContext();
        //}

        // GET: api/<CategoriasController>
        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            return _dataContext.Categoria.ToList();
            
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _dataContext.Categoria.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
            {
                return BadRequest("ID não existente");
            }
            return categoria;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] CategoriaRequest categoriaRequest)
        {
            if(ModelState.IsValid){
                var categoria = categoriaRequest.toModel();
                _dataContext.Categoria.Add(categoria);
                _dataContext.SaveChanges();
                return categoria;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
