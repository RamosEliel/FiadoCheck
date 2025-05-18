using Microsoft.AspNetCore.Mvc;
using FiadoCheck_API.Context;
using FiadoCheck_API.Models;

namespace SysPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly FiadoCheckDbContext context;

        public clientesController(FiadoCheckDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<clientes> Get()
        {
            return context.clientes.ToList();
        }

        [HttpGet("{id}")]
        public clientes Get(int id)
        {
            return context.clientes.Find(id);
        }

        [HttpPost]
        public int Post([FromBody] clientes cliente)
        {
            int result = context.clientes.Add(cliente).Context.SaveChanges();
            return result;
        }

        [HttpPut("{id}")]
        public int Put(int id, [FromBody] clientes clienteActualizado)
        {
            clientes clienteBuscado = context.clientes.FirstOrDefault(c => c.idCliente == id);

            if (clienteBuscado == null) { return 0; }

            clienteBuscado.idCliente = clienteActualizado.idCliente;
            clienteBuscado.nombreCliente = clienteActualizado.nombreCliente;
            clienteBuscado.direccion = clienteActualizado.direccion;
            clienteBuscado.telefono = clienteActualizado.telefono;
            clienteBuscado.email = clienteActualizado.email;
            clienteBuscado.fechaRegistro = clienteActualizado.fechaRegistro;

            int result = context.SaveChanges();

            return result;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            clientes? clienteBuscado = context.clientes.FirstOrDefault(c => c.idCliente == id);

            if (clienteBuscado != null)
            {
                response = context.clientes.Remove(clienteBuscado).Context.SaveChanges();
            }
            return response;
        }
    }
}
