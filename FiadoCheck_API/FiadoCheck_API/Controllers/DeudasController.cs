using Microsoft.AspNetCore.Mvc;
using FiadoCheck_API.Context;
using FiadoCheck_API.Models;

namespace FiadoCheck_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudasController : ControllerBase
    {
        private readonly FiadoCheckDbContext context;

        public DeudasController(FiadoCheckDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<deudas> Get()
        {
            return context.deudas.ToList();
        }

        [HttpGet("{id}")]
        public deudas Get(int id)
        {
            return context.deudas.Find(id);
        }

        [HttpPost]
        public int Post([FromBody] deudas deuda)
        {
            int result = context.deudas.Add(deuda).Context.SaveChanges();
            return result;
        }

        [HttpPut("{id}")]
        public int Put(int id, [FromBody] deudas deudaActualizada)
        {
            deudas deudaBuscada = context.deudas.FirstOrDefault(c => c.idDeuda == id);

            if (deudaBuscada == null) { return 0; }

            deudaBuscada.idDeuda = deudaActualizada.idDeuda;
            deudaBuscada.monto = deudaActualizada.monto;
            deudaBuscada.fechaCreacion = deudaActualizada.fechaCreacion;
            deudaBuscada.descripcion = deudaActualizada.descripcion;
            deudaBuscada.estadoDeuda = deudaActualizada.estadoDeuda;
            deudaBuscada.idCliente = deudaActualizada.idCliente;

            int result = context.SaveChanges();

            return result;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            deudas? deudaBuscada = context.deudas.FirstOrDefault(c => c.idDeuda == id);

            if (deudaBuscada != null)
            {
                response = context.deudas.Remove(deudaBuscada).Context.SaveChanges();
            }
            return response;
        }
    }
}
