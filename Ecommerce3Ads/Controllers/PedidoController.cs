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
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PedidoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            return _dataContext.Pedido.ToList();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            return _dataContext.Pedido.Find(id);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] PedidoRequest pedidoRequest)
        {
            if (ModelState.IsValid)
            {
                var pedido = pedidoRequest.toModel();
                _dataContext.Pedido.Add(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<PedidoController>/5
        [HttpPut]
        public ActionResult<Pedido> Put([FromBody] Pedido pedido)
        {
            var at = _dataContext.Pedido.Where(p => p.Id == pedido.Id).First();

            if (at == null)
            {
                return BadRequest(ModelState);
            }

            at.Pago = pedido.Pago;
            at.EnderecoComprador = pedido.EnderecoComprador.IsNullOrEmpty() ? at.EnderecoComprador : pedido.EnderecoComprador;

            _dataContext.SaveChanges();

            return Ok("Pedido atualizado com sucesso!");
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pedido = _dataContext.Pedido.Find(id);

            if (pedido == null)
            {
                ModelState.AddModelError("Id", "Pedido não encontrado!");
            }

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Remove(pedido);
                _dataContext.SaveChanges();
                return Ok("Pedido removido com sucesso!");
            }

            return BadRequest(ModelState);
        }
    }
}
