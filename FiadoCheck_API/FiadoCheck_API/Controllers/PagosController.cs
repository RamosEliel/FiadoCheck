using Microsoft.AspNetCore.Mvc;
using FiadoCheck_API.Models;
using FiadoCheck_API.Context;

namespace FiadoCheck_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PagosController : ControllerBase
    {

        private readonly FiadoCheckDbContext context;
        public PagosController(FiadoCheckDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<pagos> Get()
        {
            return context.pagos.ToList();
        }


        [HttpGet("{id}")]
        public pagos Get(int id)
        {
            return context.pagos.Find(id);
        }


        [HttpPost]
        public int Post([FromBody] pagos pago)
        {
            int result = context.pagos.Add(pago).Context.SaveChanges();
            return result;
        }


        [HttpPut("{id}")]
        public int Put(int id, [FromBody] pagos pagoActualizado)
        {
            pagos pagoBuscado = context.pagos.FirstOrDefault(p => p.idPago == id);

            if (pagoBuscado == null) { return 0; }

            pagoBuscado.idPago = pagoBuscado.idPago;
            pagoBuscado.monto = pagoBuscado.monto;
            pagoBuscado.fechaPago = pagoBuscado.fechaPago;
            pagoBuscado.idDeuda = pagoBuscado.idDeuda;
            pagoBuscado.metodoPago = pagoBuscado.metodoPago;
            int result = context.SaveChanges();

            return result;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            pagos pagoBuscado = context.pagos.FirstOrDefault(p => p.idPago == id);

            if (pagoBuscado != null)
            {
                response = context.pagos.Remove(pagoBuscado).Context.SaveChanges();
            }
            return response;
        }

    }
}
